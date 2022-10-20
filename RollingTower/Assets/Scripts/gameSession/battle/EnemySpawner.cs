using System;
using System.Collections;
using System.Collections.Generic;
using entities.enemies;
using gameSession.WaveInfo;
using UnityEngine;

namespace gameSession.battle {


    //todo: Should be part of the BattleManager : IStageManager
    public class EnemySpawner : MonoBehaviour {

        public Action<Enemy> OnEnemyInstantiate = delegate { };

        public bool isSpawning { get; private set; } = false;

        private float _innerRadius;

        private EnemyWave _currentWave;

        private List<SpawnWaveInfo> _enemySpawnInfo;

        [SerializeField]
        private float _leftSide = 10f;

        [SerializeField]
        private float _topSide = 5f;

        [SerializeField]
        private float _wallRadius = 1.5f;
        

        [SerializeField]
        private float _groupLeftSide = .2f;
        
        [SerializeField]
        private float _groupTopSide = .5f;
        
        [SerializeField]
        private float _wallGroupRadius = .3f;


        private void Awake() {
            _enemySpawnInfo = Resources.Load<EnemySpawnInfoDTO>("gameSession/spawnInfo/BaseEnemyWaves").GetSpawnInfo();
            _innerRadius = (Vector2.left * _leftSide + Vector2.up * _topSide).magnitude;
        }

        private void StartSpawningCurrentWave() {
            isSpawning = true;
        }

        private void StopSpawning() {
            isSpawning = false;
        }

        public void StartNewWave(int roundNumber) {
            StartSpawningCurrentWave();
            Debug.Log("Starting new wave from EnemySpawner");
            InitCurrentWaveByRoundNumber(roundNumber);
            SpawnCurrentWave();
        }

        private void InitCurrentWaveByRoundNumber(int roundNumber) {
            var info = FindWaveInfoByRound(roundNumber);
            EnemyWave wave = new EnemyWave();
            wave.InitWave(info);
            _currentWave = wave;
            Debug.Log("After init current wave. Current wave is: " + _currentWave);
        }

        private SpawnWaveInfo FindWaveInfoByRound(int roundNumber) {
            if (_enemySpawnInfo.Exists(wave => wave.roundNumber == roundNumber)) {
                return _enemySpawnInfo.Find(wave => wave.roundNumber == roundNumber);
            } else {
                Debug.Log("Trying to get not existed wave!!!");
                throw new ArgumentException("Non existed wave round!");
            }
        }

        private void SpawnCurrentWave() {
            SpawnWave(_currentWave);
        }

        private void SpawnWave(EnemyWave wave) {
            foreach (var enemyInfo in wave.GetEnemyWaveInfo()) {
                if (enemyInfo.isGroup) {
                    SpawnGroupCor(enemyInfo);
                } else {
                    StartCoroutine(SpawnWaveCor(enemyInfo));
                }
            }
        }

        
        //todo: move to another class
        private void SpawnGroupCor(EnemyWaveInfo enemyInfo) {
            var randomPositionInTorus = PositionVectorUtils.GetRandomPositionInTorus(_innerRadius+1f, _wallRadius);
            float innerGroupRadius = (Vector2.left * _groupLeftSide + Vector2.up * _groupTopSide).magnitude;
            while (enemyInfo.enemyCount > 0) {
                Vector3 enemyPositionInGroup =
                    PositionVectorUtils.GetRandomPositionInGroup(randomPositionInTorus, innerGroupRadius,
                        _wallGroupRadius);
                Enemy instantiatedEnemy = InstantiateEnemy(enemyInfo.enemyPrefab, enemyPositionInGroup);
                OnEnemyInstantiate.Invoke(instantiatedEnemy);
                enemyInfo.enemyCount--;
            }
            StopSpawning();
        }

        private IEnumerator SpawnWaveCor(EnemyWaveInfo waveInfo) {
            // Debug.Log("Trying to Spawn enemy");
            while (waveInfo.enemyCount > 0) {
                // Debug.Log("Spawning enemy");

                yield return new WaitForSeconds(waveInfo.spawnSpeed);
                Enemy instantiatedEnemy = InstantiateEnemy(waveInfo.enemyPrefab);
                OnEnemyInstantiate.Invoke(instantiatedEnemy);
                waveInfo.enemyCount--;
            }
            StopSpawning();
        }

        private Enemy InstantiateEnemy(Enemy enemyPrefab) {
            var randomPositionInTorus = PositionVectorUtils.GetRandomPositionInTorus(_innerRadius, _wallRadius);
            Enemy instantiatedEnemy = Instantiate(enemyPrefab, randomPositionInTorus, Quaternion.identity);
            return instantiatedEnemy;
        }

        private Enemy InstantiateEnemy(Enemy enemyPrefab, Vector3 posToSpawn) {
            Enemy instantiatedEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            return instantiatedEnemy;
        }
    }
}