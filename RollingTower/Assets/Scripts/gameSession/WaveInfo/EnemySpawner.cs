using System;
using System.Collections;
using System.Collections.Generic;
using entities.enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gameSession {

    public class EnemySpawner : MonoBehaviour {

        public Action OnWaveClear = delegate { };

        private bool _isCurrentWaveGoing = true;

        private float _innerRadius;

        private List<Enemy> _currentWaveEnemies = new();

        private EnemyWave _currentWave;

        private List<SpawnWaveInfo> _enemySpawnInfo;

        [SerializeField]
        private float _firstWaveDelay = 5f;

        [SerializeField]
        private float _leftSide = 10f;

        [SerializeField]
        private float _topSide = 5f;

        [SerializeField]
        private float _wallRadius = 1.5f;


        public static EnemySpawner GetInstance { private set; get; }

        private void Awake() {
            if (GetInstance == null)
                GetInstance = this;

            _enemySpawnInfo = Resources.Load<EnemySpawnInfoDTO>("gameSession/spawnInfo/BaseEnemyWaves").GetSpawnInfo();
            OnWaveClear += StopWave;
        }

        private void Start() {
            _innerRadius = (Vector2.left * _leftSide + Vector2.up * _topSide).magnitude;
            InitFirstWave();
            Debug.Log("Spawning first wave...");
            StartCoroutine(SpawnFirstWave(_firstWaveDelay));
        }

        private void InitFirstWave() {
            _currentWave = InitCurrentWave(FindWaveInfoByRound(1));
        }

        private void StopWave() {
            Debug.Log("Trying to stop current wave");
            _isCurrentWaveGoing = false;
        }

        private EnemyWave InitCurrentWave(SpawnWaveInfo info) {
            EnemyWave wave = new EnemyWave();
            wave.InitWave(info);
            return wave;
        }

        private EnemyWave InitCurrentWave(int roundNumber) {
            var info = FindWaveInfoByRound(roundNumber);
            EnemyWave wave = new EnemyWave();
            wave.InitWave(info);
            return wave;
        }

        private SpawnWaveInfo FindWaveInfoByRound(int roundNumber) {
            if (_enemySpawnInfo.Exists(wave => wave.roundNumber == roundNumber)) {
                return _enemySpawnInfo.Find(wave => wave.roundNumber == roundNumber);
            } else {
                Debug.Log("Trying to get not existed wave!!!");
                throw new ArgumentException("Non existed wave round!");
            }
        }

        private void SpawnWave(EnemyWave wave) {
            foreach (var enemyInfo in wave.GetEnemyWaveInfo()) {
                StartCoroutine(SpawnWaveCor(enemyInfo));
            }
        }

        private IEnumerator SpawnFirstWave(float delay) {
            yield return new WaitForSeconds(delay);
            SpawnWave(_currentWave);
        }

        private IEnumerator SpawnWaveCor(EnemyWaveInfo waveInfo) {
            // Debug.Log("Trying to Spawn enemy");
            while (_isCurrentWaveGoing && waveInfo._enemyCount > 0) {
                // Debug.Log("Spawning enemy");

                yield return new WaitForSeconds(waveInfo._spawnSpeed);
                Enemy instantiateEnemy = InstantiateEnemy(waveInfo.enemyPrefab);
                instantiateEnemy.OnDie += RemoveEnemyFromCurrent;
                _currentWaveEnemies.Add(instantiateEnemy);
                waveInfo._enemyCount--;
            }
        }

        private void RemoveEnemyFromCurrent(Enemy enemy) {
            _currentWaveEnemies.Remove(enemy);
            // Debug.Log("Removing enemy from list");
            if (!_currentWave.IsEnemyLeft() && _currentWaveEnemies.Count <= 0) {
                Debug.Log("Invoking OnWaveClear");
                OnWaveClear.Invoke();
            }
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