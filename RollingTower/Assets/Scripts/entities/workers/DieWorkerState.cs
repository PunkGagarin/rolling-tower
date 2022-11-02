public class DieWorkerState : BaseWorkerState {

    protected override void InitSpecificState() {
        type = WorkerStateType.DieState;
    }

    public override void Start() {
        //todo: play die animation
    }

    public override void Tick() {
    }

    public override void CheckOnTransitionConditions() {
        //todo: check on die animation end
        _owner.EndOfWork();
    }
}