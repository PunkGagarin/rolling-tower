using System.Collections.Generic;
using System.Linq;
using entities.player.citadels;

public class WorkerStatesController : IStateSwitcher<BaseWorkerState> {
    private BaseWorkerState _currentState;
    private List<BaseWorkerState> _allStates;
    private AbstractMovement<WorkerStat, WorkerStatType> _movement;

    public void Tick() {
        _currentState.Tick();
        _currentState.CheckOnTransitionConditions();
    }

    public void Init(Worker worker, AbstractMovement<WorkerStat, WorkerStatType> movement, WorkerStateType startState) {
        movement.Init(worker.Stats.getStatByType(WorkerStatType.MoveSpeed), worker.transform, worker.transform);
        _allStates = new List<BaseWorkerState>() {
            WorkerStateFactory.GetWorkerStateByType(WorkerStateType.GoingToBase),
            WorkerStateFactory.GetWorkerStateByType(WorkerStateType.GoingToResource),
            WorkerStateFactory.GetWorkerStateByType(WorkerStateType.Extraction),
            WorkerStateFactory.GetWorkerStateByType(WorkerStateType.ResourceUnloading),
            WorkerStateFactory.GetWorkerStateByType(WorkerStateType.FindingResourcePlace),
            WorkerStateFactory.GetWorkerStateByType(WorkerStateType.EndState)
        };
        foreach (var state in _allStates) {
            //todo: inject Citadel
            state.InitBase(worker, this, movement, Citadel.GetInstance.transform, InGameResourceStorage.GetInstance);
        }
        _currentState = _allStates.Find(state => state.type.Equals(startState));
        _currentState.Start();
    }
    
    public void SwitchState<S>() where S : BaseWorkerState {
        var newState = _allStates.FirstOrDefault(s => s is S);
        _currentState.Stop();
        newState.Start();
        _currentState = newState;
    }

    public string GetCurrentStateStringType() => _currentState.GetType().ToString();
}