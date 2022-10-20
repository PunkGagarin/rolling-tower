using System;
using System.Collections.Generic;
using gameSession.battle;

namespace gameSession.WaveInfo {

    [Serializable]
    public class EnemyWave {

        public int waveNumber { get; private set; }

        private List<EnemyWaveInfo> _enemyWaveInfo = new();

        public bool IsEnemyLeft() {
            bool isAnythingLeft = false;
            foreach (var waveInfo in _enemyWaveInfo) {
                if (waveInfo.enemyCount > 0)
                    isAnythingLeft = true;
            }
            return isAnythingLeft;
        }

        public void InitWave(SpawnWaveInfo spawnWaveInfo) {
            waveNumber = spawnWaveInfo.roundNumber;
            foreach (var enemyPair in spawnWaveInfo.enemies) {
                _enemyWaveInfo.Add(new EnemyWaveInfo(enemyPair));
            }
        }

        public List<EnemyWaveInfo> GetEnemyWaveInfo() {
            return _enemyWaveInfo;
        }
    }

}