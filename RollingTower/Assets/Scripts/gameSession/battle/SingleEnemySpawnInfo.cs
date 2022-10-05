using System;

namespace gameSession.battle {

    [Serializable]
    public class SingleEnemySpawnInfo {
        public EnemyUnitType _enemyUnitType;
        public int _enemyCount;
        public float _spawnSpeed = 1f;
        public bool _isGroup;
    }

}