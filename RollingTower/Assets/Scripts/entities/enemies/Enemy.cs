using entities.bases;
using entities.player.citadels;
using UnityEngine;

namespace entities.enemies {

    [RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
    public class Enemy : HealthUnit<UnitStatType, EnemyStats, UnitStat>, IDamageable {
        private AbstractMovement _movementBehaviour;
        private AbstractUnitAttack _attackBehaviour;

        private Transform _target;

        private EnemyMoveType _enemyMoveType;

        [SerializeField]
        private AttackType _attackType;


        private float _distance;

        protected override void Awake() {
            base.Awake();
            _movementBehaviour = MoveFactory.GetMoveBehaviour(_enemyMoveType);
            _attackBehaviour = AttackTypeFactory.GetAttackBehaviourByType(_attackType);
        }

        private void Start() {
            _target = Citadel.GetInstance.transform;
            InitBehaviours();
        }

        private void InitBehaviours() {
            var speedStat = _stats.getStatByType(UnitStatType.MoveSpeed);
            var damageStat = _stats.getStatByType(UnitStatType.Damage);
            _attackBehaviour.Init(damageStat.currentValue);
            _movementBehaviour.Init(speedStat.currentValue, transform, GetComponent<Rigidbody2D>());

            damageStat.OnValueChange += _attackBehaviour.SetDamage;
            speedStat.OnValueChange += _movementBehaviour.SetSpeed;

            _movementBehaviour.SetTarget(_target);
        }

        public void Update() {
            if (IsNeedToMove()) {
                _movementBehaviour.Move();
            } else {
                //todo: remove comments
                //_attackBehaviour.Attack(_target);
            }
        }

        protected override UnitStat getHealth() {
            return _stats.getAllStats()[UnitStatType.Health];
        }

        private bool IsNeedToMove() {
            var distance = _target.position - transform.position;
            var range = _stats.getStatByType(UnitStatType.AttackRange).currentValue;
            return !(distance.sqrMagnitude <= range * range);
        }
    }

}