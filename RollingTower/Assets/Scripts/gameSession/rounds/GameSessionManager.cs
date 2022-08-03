using System;
using UnityEngine;

public class GameSessionManager : MonoBehaviour {

    public Action<RoundStageType, RoundStageType> OnRoundStageOver = delegate { };

    private RoundStageType _currentRoundStageType;

    public bool isGameOver { get; private set; }

    private int _currentRoundNumber;

    [SerializeField]
    private int _maxRoundNumber = 20;

    public static GameSessionManager GetInstance { get; private set; }

    private void Awake() {
        if (GetInstance == null) {
            GetInstance = this;
        }
        OnRoundStageOver += OnRoundStageOverHandler;
    }

    private void Start() {
    }

    public void GoToNextStage() {
        Debug.Log("We are chaning current stage from: " + _currentRoundStageType);
        if (_currentRoundStageType == RoundStageType.Fighting) {
            _currentRoundStageType = RoundStageType.CardChoosing;
            OnRoundStageOver.Invoke(RoundStageType.Fighting, RoundStageType.CardChoosing);
        } else if (_currentRoundStageType == RoundStageType.CardChoosing) {
            _currentRoundStageType = RoundStageType.ResourceGathering;
            OnRoundStageOver.Invoke(RoundStageType.CardChoosing, RoundStageType.ResourceGathering);
            //showCardChoosingUI should be implemented in another class and be subscribed to this event
        } else if (_currentRoundStageType == RoundStageType.ResourceGathering) {
            _currentRoundStageType = RoundStageType.Fighting;
            _currentRoundNumber++;
            OnRoundStageOver.Invoke(RoundStageType.ResourceGathering, RoundStageType.Fighting);
        } else {
            throw new ArgumentOutOfRangeException();
        }
    }

    private void OnRoundStageOverHandler(RoundStageType prevStageType, RoundStageType nextStageType) {
        Debug.Log("Round stage over: " + prevStageType + " next stage: " + nextStageType);
    }


    private void ChangeGameState() {
    }


}