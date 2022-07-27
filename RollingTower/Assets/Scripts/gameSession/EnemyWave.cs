using System;
using System.Collections.Generic;
using System.Linq;
using entities.enemies;
using UnityEngine;

[Serializable]
public class EnemyWave {

    public int _enemyToSpawnCounter { private set; get; }

    private List<Enemy> _enemies = new();

    [SerializeField]
    private List<SpawnWaveInfo> _spawnWaveInfo;

    public bool isEnemyLeft => _enemies.Count > 0;

    public void InitWave() {
        foreach (var waveInfo in _spawnWaveInfo) {
            _enemyToSpawnCounter += waveInfo._enemyCount;
        }
    }

    public void DecreaseSpawnCounter() {
        _enemyToSpawnCounter--;
    }

    public Enemy GetNextEnemyToSpawn() {
        return _enemies.FirstOrDefault();
    }

}