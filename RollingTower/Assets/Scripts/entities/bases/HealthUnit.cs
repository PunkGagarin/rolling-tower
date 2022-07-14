using System;
using System.Collections.Generic;
using Entities.Citadels;
using enums.citadels;
using UnityEngine;

namespace entities.bases {

    public abstract class HealthUnit<UST, USS, US> : MonoBehaviour where USS : IUnitStats<UST, US> where US: IUnitStat<UST> {

        public Action OnDie = delegate { };

        private USS _stats;

        public bool isDead { get; set; } = false;

        public void TakeDamage(float damage) {
            if (damage <= 0) return;
            var health = getHealth();
            health.DecreaseCurrentValue(damage);

            if (health.getCurrentValue() == 0) {
                Die();
            }
        }

        protected abstract US getHealth();

        private void Die() {
            OnDie?.Invoke();
            isDead = true;
        }
    }

    public interface IUnitStats<UST, US> {
        public Dictionary<UST, US> getAllStats();
    }

}