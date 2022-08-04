using entities.player.citadels;
using entities.player.towers;
using enums.citadels;
using enums.towers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpawnCitadel : MonoBehaviour {

    [SerializeField]
    private Citadel _citadel;

    [SerializeField]
    private Button _changeRadiusTower;

    [SerializeField]
    private Button _unlockSlotButton;

    [SerializeField]
    private Button _buildTowerButton;
    
    [SerializeField]
    private Button _addStatButton;

    [SerializeField]
    private float _radiusToIncrease = 1.5f;

    [SerializeField]
    private Tower _towerToBuildTest;


    private void Awake() {
        _citadel = Instantiate(_citadel, transform);
        _changeRadiusTower.onClick.AddListener(ChangeTowerRadiusInvoke);
        _unlockSlotButton.onClick.AddListener(UnlockSecondSlotInvoke);
        _buildTowerButton.onClick.AddListener(BuildTowerInvoke);
        _addStatButton.onClick.AddListener(AddStat);
    }

    private void ChangeTowerRadiusInvoke() {
        _citadel.AddFightingStatToCitadel(TowerStatType.AttackRange, _radiusToIncrease);

    }

    private void UnlockSecondSlotInvoke() {
        _citadel.UnlockTowerSlot(2);
    }

    private void BuildTowerInvoke() {
        _citadel.BuildTower(_towerToBuildTest, 2);
    }

    private void AddStat() {
        _citadel.AddFightingStatToCitadel(TowerStatType.AttackSpeed, 10);
    }
}