using System.Collections.Generic;
using entities.bases.Stats;
using UnityEngine;

namespace entities.bases {

    public class BaseStats<UST, US> : MonoBehaviour, IUnitStats<UST, US> {
        
        protected Dictionary<UST, US> allStats { get; } = new();

        public Dictionary<UST, US> getAllStats() {
            return allStats;
        }

        public US getStatByType(UST type) {
            if (!allStats.ContainsKey(type)) {
                Debug.Log("Trying to get not existed stat:" + type + " from: " + transform.name);
            }
            return allStats[type];
        }
    }

}