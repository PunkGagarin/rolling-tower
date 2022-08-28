using System;

namespace gameSession.battle {

    [Serializable]
    public class SpawnWaveInfo {
        public int roundNumber;
        public SingleEnemySpawnInfo[] enemies;
    }

}