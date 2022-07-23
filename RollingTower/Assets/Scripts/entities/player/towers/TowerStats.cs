using enums.towers;

namespace entities.player.towers {

    public class TowerStats : BaseTowerStats {

        private Tower _towerOwner;
        
        protected override void Awake() {
            _towerOwner = GetComponent<Tower>();
            base.Awake();
        }
        
        
        protected override void InitStats() {
            base.InitStats();
            SubscribeToStats();
        }
        
        private void SubscribeToStats() {
            getStatByType(TowerStatType.AttackRange).OnValueChange += _towerOwner.ChangeAttackRadius;
        }
    }

}