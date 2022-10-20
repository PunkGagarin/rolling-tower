using entities.enemies;

public abstract class EnemyBehaviours<AB, MB> : Enemy where AB : AbstractAttackBehaviour where MB : AbstractMovement {
    
    protected AB _attackBehaviour;
    protected MB _moveBehaviour;
    
    private AttackSpeedController<UnitStat, UnitStatType> _attackSpeed = new();

    protected override void Start() {
        base.Start();
        InitBehaviours();
        _attackSpeed.Init(_stats.getStatByType(UnitStatType.AttackSpeed), _attackBehaviour.Attack);
    }

    public void Update() {
        if (IsNeedToMove()) {
            _moveBehaviour.Move();
        } else {
            _attackSpeed.TryAttack();
        }
        _attackSpeed.Tick();
    }

    private bool IsNeedToMove() {
        var distance = _citadel.transform.position - transform.position;
        var range = _stats.getStatByType(UnitStatType.AttackRange).currentValue;
        return !(distance.sqrMagnitude <= range * range);
    }

    private void InitBehaviours() {
        InitMoveBehaviour();
        InitAttackBehaviour();
    }

    protected abstract void InitAttackBehaviour();
    protected abstract void InitMoveBehaviour();
}