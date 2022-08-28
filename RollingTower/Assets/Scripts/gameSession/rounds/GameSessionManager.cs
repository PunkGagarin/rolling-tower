using System;
using System.Collections;
using enums.gameSession.rounds;
using gameSession.battle;
using gameSession.cards;
using gameSession.gathering;
using UnityEngine;

namespace gameSession.rounds {

    public class GameSessionManager : MonoBehaviour {
        
        private RoundStageType _currentRoundStageType = RoundStageType.Fighting;

        private int _currentRoundNumber = 1;

        private CardChoosingManager _cardChoosingManager;

        private FightingManager _fightingManager;

        private GatheringManager _gatheringManager;

        //TODO: move to another class maybe?
        public bool isGameOver { get; private set; }
        
        public bool isGameWon { get; private set; }
        
        [SerializeField]
        private float _startFirstRoundDelay = 5f;

        [SerializeField]
        private int _maxRoundNumber = 20;

        public static GameSessionManager GetInstance { get; private set; }

        private void Awake() {
            if (GetInstance != null && GetInstance != this) {
                Destroy(this);
            } else {
                GetInstance = this;
            }
        }


        private void Start() {
            _cardChoosingManager = GetComponent<CardChoosingManager>();
            _cardChoosingManager.OnCardChoose += EndChooseStage;

            _fightingManager = FightingManager.GetInstance;
            _fightingManager.OnWaveClear += EndFightingStage;
            
            _gatheringManager = GatheringManager.GetInstance;
            _gatheringManager.OnGatheringFinish += EndGatheringStage;

            StartFirstRound();
        }

        private void StartFirstRound() {
            StartCoroutine(StartFirstRound(_startFirstRoundDelay));
        }

        private IEnumerator StartFirstRound(float delay) {
            yield return new WaitForSeconds(delay);
            _fightingManager.StartNewWave(1);
        }

        private void EndFightingStage() {
            PassToNextRound();
            EndCurrentStage(RoundStageType.Fighting);
        }

        private void EndChooseStage() {
            EndCurrentStage(RoundStageType.CardChoosing);
        }

        private void EndGatheringStage() {
            EndCurrentStage(RoundStageType.ResourceGathering);
        }

        private void EndCurrentStage(RoundStageType type) {
            if (_currentRoundStageType.Equals(type)) {
                EndCurrentStageAndChangeToNext();
            } else {
                Debug.Log(
                    $"We just ended stage type  {type}, but unable to pass to the next stage, because current stage is {_currentRoundStageType}");
            }
        }

        private void EndCurrentStageAndChangeToNext() {
            Debug.Log("We are chaning current stage from: " + _currentRoundStageType);
            if (isGameWon || isGameOver) {
                Debug.Log("Trying to keep playing while game is already over");
                return;
            }
            switch (_currentRoundStageType) {
                case RoundStageType.Fighting:
                    StartCardChoosingStage();
                    break;
                case RoundStageType.CardChoosing:
                    StartResourceGatheringStage();
                    break;
                case RoundStageType.ResourceGathering:
                    StartFightingStage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartCardChoosingStage() {
            _currentRoundStageType = RoundStageType.CardChoosing;
            _cardChoosingManager.StartStage();
        }

        private void StartResourceGatheringStage() {
            _currentRoundStageType = RoundStageType.ResourceGathering;
            _gatheringManager.StartStage();
        }

        private void StartFightingStage() {
            _currentRoundStageType = RoundStageType.Fighting;
            _fightingManager.StartNewWave(_currentRoundNumber);
        }

        private void PassToNextRound() {
            if (_currentRoundNumber >= _maxRoundNumber) {
                FinishGame();
            } else {
                _currentRoundNumber++;
            }
        }

        private void FinishGame() {
            //TODO: implement FinishGame logic
            isGameWon = true;
            Debug.Log("Congratulations, You Have Won !!!!");
        }
    }

}