using System.Collections.Generic;
using System.Linq;

public class WorkerStatesController : IStateSwitcher<BaseWorkerState> {
    private BaseWorkerState _currentState;
    private List<BaseWorkerState> _allStates;

    public void Tick() {
        _currentState.Tick();
        _currentState.CheckOnTransitionConditions();
    }

    public void Init(Worker worker) {
        _allStates = new List<BaseWorkerState>() {
            new GoingToResourceWorkerState(worker),
            new ExtractionWorkerState(worker),
            new GoingToBaseWorkerState(worker),
            new UnloadingWorkerState(worker)
        };
        _currentState = _allStates[0];
    }
    
    public void SwitchState<S>() where S : BaseWorkerState {
        var newState = _allStates.FirstOrDefault(s => s is S);
        _currentState.Stop();
        newState.Start();
        _currentState = newState;
    }

    public string GetCurrentStateStringType() => _currentState.GetType().ToString();
}