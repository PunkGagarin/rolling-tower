using entities.enemies;
using UnityEngine;
using Zenject;

namespace gameSession.battle {

    public class EnemyFactory {

        [Inject]
        private DiContainer _diContainer;
        
        public Enemy InstantiateEnemy(Enemy enemyPrefab, Vector2 pos) {
            Enemy instantiatedEnemy =
                _diContainer.InstantiatePrefabForComponent<Enemy>(enemyPrefab, pos,
                    Quaternion.identity, null);
            return instantiatedEnemy;
        }
    }

}