public class GoingToResourceWorkerState : BaseWorkerState {
    public GoingToResourceWorkerState(Worker owner) : base(owner) { }
    
    public override void Tick() {
        //going to resource place
    }

    public override void CheckOnTransitionConditions() {
        _stateSwitcher.SwitchState<ExtractionWorkerState>();
    }
}