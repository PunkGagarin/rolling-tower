using entities.bases;
using entities.player.citadels;
using UnityEngine;

namespace entities.enemies {

    [RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
    public class Enemy : HealthUnit<UnitStatType, EnemyStats, UnitStat>, IDamageable, IDamageDealer {
        private AbstractMovement _movementBehaviour;
        private AbstractUnitAttack _attackBehaviour;

        private EnemyMoveType _enemyMoveType;

        [SerializeField]
        private AttackType _attackType;

        [SerializeField]
        private EnemyUnitType _enemyUnitType;

        private float _distance;
        private Citadel _citadel;

        protected override void Awake() {
            base.Awake();
            _movementBehaviour = MoveFactory.GetMoveBehaviour(_enemyMoveType);
            _attackBehaviour = AttackTypeFactory.GetAttackBehaviourByType(_attackType);
        }

        private void Start() {
            _citadel = Citadel.GetInstance;
            InitBehaviours();
        }

        private void InitBehaviours() {
            var speedStat = _stats.getStatByType(UnitStatType.MoveSpeed);
            var damageStat = _stats.getStatByType(UnitStatType.Damage);
            _attackBehaviour.Init(damageStat, this);
            _movementBehaviour.Init(speedStat.currentValue, transform, GetComponent<Rigidbody2D>());
            
            speedStat.OnValueChange += _movementBehaviour.SetSpeed;

            _movementBehaviour.SetTarget(_citadel.transform);
        }

        public void Update() {
            if (IsNeedToMove()) {
                _movementBehaviour.Move();
            } else {
                _attackBehaviour.Attack(_citadel);
            }
        }

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
    }
}