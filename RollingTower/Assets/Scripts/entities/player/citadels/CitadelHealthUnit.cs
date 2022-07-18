using System;
using entities.bases;
using Entities.Citadels;
using enums.citadels;
using UnityEngine;

namespace entities.player.citadels {

    public class CitadelHealthUnit : HealthUnit<CitadelStatType, CitadelStats, CitadelStat>, IDamageable {

        private float hpRegenTimeInterval = 1f;

        private float currentHpRegenTimer = 1f;

        private void Update() {
            currentHpRegenTimer -= Time.deltaTime;
            if (currentHpRegenTimer <= 0) {
                regenerateHealth();
            }
        }

        private void regenerateHealth() {
            var health = getHealth();
            if (health.isMaxValue()) return;
            float hpRegenValue = _stats.getStatByType(CitadelStatType.HpRegen).getCurrentValue();
            health.IncreaseCurrentValue(hpRegenValue);
        }

        protected override CitadelStat getHealth() {
            return _stats.getStatByType(CitadelStatType.Health);
        }
        
        protected override void decreaseHealth(float damage, CitadelStat health) {
            damage -= _stats.getStatByType(CitadelStatType.Armor).currentValue;
            base.decreaseHealth(damage, health);
        }
    }

}