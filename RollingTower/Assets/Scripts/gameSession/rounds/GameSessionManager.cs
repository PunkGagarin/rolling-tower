using System;
using gameSession;
using UnityEngine;

public class GameSessionManager : MonoBehaviour {

    public Action<RoundStageType, RoundStageType> OnRoundStageOver = delegate { };

    private RoundStageType _currentRoundStageType;

    private CardChoosingManager _cardChoosingManager;

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
        _cardChoosingManager = GetComponent<CardChoosingManager>();
        _cardChoosingManager.OnCardChoose += EndChooseStage;
    }


    private void Start() {
        EnemySpawner.GetInstance.OnWaveClear += EndFightingStage;
    }

    private void EndFightingStage() {
        if (_currentRoundStageType.Equals(RoundStageType.Fighting)) {
            GoToNextStage();
        } else {
            Debug.Log("Wave just cleared but we cant move to the next stage, current stage type is not Fighting!");
        }
    }
    
    
    private void EndChooseStage() {
        if (_currentRoundStageType.Equals(RoundStageType.CardChoosing)) {
            GoToNextStage();
        } else {
            Debug.Log("Wave just choose a card but we cant move to the next stage, current stage type is not CardChoosing!");
        }
    }

    public void GoToNextStage() {
        Debug.Log("We are chaning current stage from: " + _currentRoundStageType);
        if (_currentRoundStageType == RoundStageType.Fighting) {
            _currentRoundStageType = RoundStageType.CardChoosing;
            OnRoundStageOver.Invoke(RoundStageType.Fighting, RoundStageType.CardChoosing);
            _cardChoosingManager.ActivateCardChoosingStage();
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