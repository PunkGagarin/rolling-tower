using entities.enemies;
using gameSession.battle;

namespace gameSession.WaveInfo {

    public class EnemyWaveInfo {
        public Enemy enemyPrefab { get; private set; }
        public int enemyCount { get; set; }
        public float spawnSpeed { get; private set; }
        
        public bool isGroup { get; private set; }

        public EnemyWaveInfo(SingleEnemySpawnInfo singleEnemySpawnInfo) {
            enemyPrefab = EnemyPrefabFactory.GetInstance.GetPrefabByType(singleEnemySpawnInfo._enemyUnitType);
            enemyCount = singleEnemySpawnInfo._enemyCount;
            spawnSpeed = singleEnemySpawnInfo._spawnSpeed;
            isGroup = singleEnemySpawnInfo._isGroup;
        }
    }

}