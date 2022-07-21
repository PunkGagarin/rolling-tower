using entities.bases;
using entities.player.citadels;
using UnityEngine;

namespace entities.enemies {

    [RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
    public abstract class Enemy : HealthUnit<UnitStatType, EnemyStats, UnitStat>, IDamageable, IDamageDealer {
        protected AbstractMovement _movementBehaviour;
        protected AbstractUnitAttack _attackBehaviour;
        private EnemyMoveType _enemyMoveType;

        [SerializeField]
        private EnemyUnitType _enemyUnitType;
        
        [SerializeField]
        protected Transform _firePoint;
        
        protected Citadel _citadel;
        
        private float _attackMaxTimer;
        private float _currentAttackTimer;

        private void Start() {
            _citadel = Citadel.GetInstance;
            _stats.getStatByType(UnitStatType.Damage);
            InitBehaviours();
            SetProperAttackTime();
        }

        private void InitBehaviours() {
            InitMoveBehaviour();
            InitAttackBehaviour();
        }

        public void Update() {
            if (IsNeedToMove()) {
                _movementBehaviour.Move();
            } else {
                TryAttack();
            }
            _currentAttackTimer -= Time.deltaTime;
        }

        #region AttackSpeed

        //todo: move attack speed logic in proper class or stats(same logic we already have in towers)  
        private void SetProperAttackTime() {
            _attackMaxTimer = 10 / _stats.getStatByType(UnitStatType.AttackSpeed).currentValue;
            _currentAttackTimer = _attackMaxTimer;
        }
        
        private void TryAttack() {
            if (_currentAttackTimer <= 0) {
                _currentAttackTimer = _attackMaxTimer;
                _attackBehaviour.Attack();
            }
        }

        #endregion

        protected override UnitStat getHealth() {
            return _stats.getAllStats()[UnitStatType.Health];
        }
        
        public void DealDamage(IDamageable damageableTarget) {
            float enemyDamage = _stats.getStatByType(UnitStatType.Damage).currentValue;
            Debug.Log("Deal damage to : " + enemyDamage);
            damageableTarget.TakeDamage(enemyDamage);
        }

        private bool IsNeedToMove() {
            var distance = _citadel.transform.position - transform.position;
            var range = _stats.getStatByType(UnitStatType.AttackRange).currentValue;
            return !(distance.sqrMagnitude <= range * range);
        }

        public EnemyUnitType enemyUnitType => _enemyUnitType;
        
        public Transform currentTransform => transform;

        protected abstract void InitAttackBehaviour();
        protected abstract void InitMoveBehaviour();
    }
}