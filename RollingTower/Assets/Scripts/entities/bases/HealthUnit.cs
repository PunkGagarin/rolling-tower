using System;
using entities.bases.Stats;
using UnityEngine;

namespace entities.bases {

    public abstract class HealthUnit<UST, USS, US> : MonoBehaviour
        where USS : IUnitStats<UST, US> where US : IUnitStat<UST> {

        public Action OnDie = delegate { };

        protected USS _stats;

        public bool isDead { get; protected set; }

        protected virtual void Awake() {
            _stats = GetComponent<USS>();
        }

        public virtual void TakeDamage(float damage) {
            if (damage <= 0) return;
            var health = getHealth();
            decreaseHealth(damage, health);

            if (health.getCurrentValue() == 0) {
                Die();
            }
        }

        protected virtual void decreaseHealth(float damage, US health) {
            health.DecreaseCurrentValue(damage);
        }

        protected abstract US getHealth();

        protected virtual void Die() {
            OnDie?.Invoke();
            isDead = true;
        }
    }

}