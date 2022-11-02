using System;

public class WorkerStateFactory {
    public static BaseWorkerState GetWorkerStateByType(WorkerStateType type) {
        switch (type) {
            case WorkerStateType.GoingToBase:
                return new GoingToBaseWorkerState();
            case WorkerStateType.GoingToResource:
                return new GoingToResourceWorkerState();
            case WorkerStateType.Extraction:
                return new ExtractionWorkerState();
            case WorkerStateType.ResourceUnloading:
                return new UnloadingWorkerState();
            case WorkerStateType.FindingResourcePlace:
                return new FindingResourcePlaceWorkerState();
            case WorkerStateType.EndState:
                return new EndWorkerState();
            case WorkerStateType.DieState:
                return new DieWorkerState();
        }
        throw new ArgumentException($"Have no state with type: {type}");
    }
}