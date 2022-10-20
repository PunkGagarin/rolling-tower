using System;
using System.Collections.Generic;
using entities.enemies;
using UnityEngine;

namespace gameSession.battle {

    public class FightingManager : MonoBehaviour, IStageManager {
        
        public Action OnWaveClear = delegate { };

        private EnemySpawner _enemySpawner;
        
        private List<Enemy> _currentWaveEnemies = new();
        

        private void Awake() {
            _enemySpawner = GetComponent<EnemySpawner>();
            _enemySpawner.OnEnemyInstantiate += AddEnemyToList;
        }
        
        public void StartStage() {
            throw new NotImplementedException();
        }

        public void EndStage() {
            OnWaveClear.Invoke();
        }

        private void AddEnemyToList(Enemy enemy) {
            enemy.OnDie += RemoveEnemyFromCurrent;
            _currentWaveEnemies.Add(enemy);
        }

        public void StartNewWave(int roundNumber) {
            Debug.Log("Starting new wave from EnemySpawner");
            _enemySpawner.StartNewWave(roundNumber);
        }

        private void RemoveEnemyFromCurrent(Enemy enemy) {
            _currentWaveEnemies.Remove(enemy);
            // Debug.Log("Removing enemy from list");
            
            if (!_enemySpawner.isSpawning && _currentWaveEnemies.Count <= 0) {
                Debug.Log("Invoking OnWaveClear");
                EndStage();
            }
        }

    }

}