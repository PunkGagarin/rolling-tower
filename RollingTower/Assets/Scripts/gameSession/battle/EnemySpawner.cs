using System;
using System.Collections;
using System.Collections.Generic;
using entities.enemies;
using gameSession.WaveInfo;
using UnityEngine;
using Random = UnityEngine.Random;

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


        private void Awake() {
            _enemySpawnInfo = Resources.Load<EnemySpawnInfoDTO>("gameSession/spawnInfo/BaseEnemyWaves").GetSpawnInfo();
            _innerRadius = (Vector2.left * _leftSide + Vector2.up * _topSide).magnitude;
        }

        public void StartSpawningCurrentWave() {
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
                StartCoroutine(SpawnWaveCor(enemyInfo));
            }
        }

        private IEnumerator SpawnWaveCor(EnemyWaveInfo waveInfo) {
            // Debug.Log("Trying to Spawn enemy");
            while (waveInfo._enemyCount > 0) {
                // Debug.Log("Spawning enemy");

                yield return new WaitForSeconds(waveInfo._spawnSpeed);
                Enemy instantiatedEnemy = InstantiateEnemy(waveInfo.enemyPrefab);
                OnEnemyInstantiate.Invoke(instantiatedEnemy);
                waveInfo._enemyCount--;
            }
            StopSpawning();
        }

        private Enemy InstantiateEnemy(Enemy enemyPrefab) {
            Enemy instantiatedEnemy = Instantiate(enemyPrefab, GetRandomPositionInTorus(), Quaternion.identity);
            return instantiatedEnemy;
        }


        private Vector2 GetRandomPositionInTorus() {
            float rndAngle = Random.value * 6.28f; // use radians, saves converting degrees to radians

            // determine position
            float cX = Mathf.Sin(rndAngle);
            float cY = Mathf.Cos(rndAngle);

            Vector2 ringPos = new Vector2(cX, cY);
            ringPos *= _innerRadius;

            // At any point around the center of the ring
            // a circle of radius the same as the wallRadius will fit exactly into the torus.
            // Simply get a random point in a sphere of radius wallRadius,
            // then add that to the random center point
            Vector2 sPos = Random.insideUnitCircle * _wallRadius;

            return (ringPos + sPos);
        }
    }

}