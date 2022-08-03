using System;
using System.Collections.Generic;
using System.Linq;
using entities.enemies;
using UnityEngine;


// [CreateAssetMenu(menuName = "Enemy/Factory/EnemyPrefabs", fileName = "new EnemyPrefabFactory")]
public class EnemyPrefabFactory : MonoBehaviour {

    private List<Enemy> _enemyPrefabs;
    
    public static EnemyPrefabFactory GetInstance { get; private set; }

    private void Awake() {
        if (GetInstance == null) {
            GetInstance = this;
        }
        _enemyPrefabs = Resources.LoadAll<Enemy>("Enemies").ToList();
    }

    public Enemy GetEnemyPrefabByType(EnemyUnitType type) {
        if (IsEnemyExists(type)) {
            return FindEnemy(type);
        } else {
            Debug.Log("Trying to get not existed enemy!");
            throw new ArgumentException("Enemy not exists!");
        }
    }

    private Enemy FindEnemy(EnemyUnitType type) {
        return _enemyPrefabs.Find(prefab => prefab.enemyUnitType.Equals(type));
    }

    private bool IsEnemyExists(EnemyUnitType type) {
        return _enemyPrefabs.Exists(prefab => prefab.enemyUnitType.Equals(type));
    }
}