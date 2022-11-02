using System;
using System.Collections.Generic;
using System.Linq;
using entities.player.citadels;

public class WorkerStatesController : IStateSwitcher<BaseWorkerState> {
    private BaseWorkerState _currentState;
    private List<BaseWorkerState> _allStates = new();
    private AbstractMovement<WorkerStat, WorkerStatType> _movement;

    public void Tick() {
        _currentState.Tick();
        _currentState.CheckOnTransitionConditions();
    }

    public void Init(Worker worker, AbstractMovement<WorkerStat, WorkerStatType> movement, WorkerStateType startState) {
        movement.Init(worker.Stats.getStatByType(WorkerStatType.MoveSpeed), worker.transform, worker.transform);
        
        foreach (var workerStateType in Enum.GetValues(typeof(WorkerStateType)).Cast<WorkerStateType>()) {
            _allStates.Add(WorkerStateFactory.GetWorkerStateByType(workerStateType));
        }
        
        foreach (var state in _allStates) {
            state.InitBase(worker, this, movement, Citadel.GetInstance, InGameResourceStorage.GetInstance);
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