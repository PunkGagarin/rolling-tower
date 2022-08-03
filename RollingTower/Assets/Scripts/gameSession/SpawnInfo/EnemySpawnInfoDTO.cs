using System.Collections.Generic;
using UnityEngine;

namespace gameSession {

    [CreateAssetMenu(menuName = "Enemy/Waves", fileName = "new EnemyWaves")]
    public class EnemySpawnInfoDTO : ScriptableObject {

        [SerializeField]
        private List<SpawnWaveInfo> _spawnWaveInfo;

        public List<SpawnWaveInfo> GetSpawnInfo() {
            return _spawnWaveInfo;
        }
    }

}