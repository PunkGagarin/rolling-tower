public class GoingToBaseWorkerState : BaseWorkerState {
    public GoingToBaseWorkerState(Worker owner) : base(owner) { }

    public override void Tick() {
        //going to base
    }

    public override void CheckOnTransitionConditions() {
        _stateSwitcher.SwitchState<UnloadingWorkerState>();
    }
}