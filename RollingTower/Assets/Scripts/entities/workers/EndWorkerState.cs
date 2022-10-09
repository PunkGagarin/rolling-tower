public class EndWorkerState : BaseWorkerState {
    
    protected override void InitSpecificState() {
        type = WorkerStateType.EndState;
    }

    public override void Start() {
        _owner.EndOfWork();
    }

    public override void Tick() {
        //nothing happent here
    }

    public override void CheckOnTransitionConditions() {
        //this is the last state 
    }
}