using entities.enemies;

public class EnemyWaveInfo {
    public Enemy enemyPrefab { get; private set; }
    public int _enemyCount { get; set; }
    public float _spawnSpeed { get; private set; }

    public EnemyWaveInfo(SingleEnemySpawnInfo singleEnemySpawnInfo) {
        enemyPrefab = EnemyPrefabFactory.GetInstance.GetPrefabByType(singleEnemySpawnInfo._enemyUnitType);
        _enemyCount = singleEnemySpawnInfo._enemyCount;
        _spawnSpeed = singleEnemySpawnInfo.spawnSpeed;
    }
}