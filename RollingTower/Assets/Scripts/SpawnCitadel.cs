using entities.player.citadels;
using entities.player.towers;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCitadel : MonoBehaviour {

    [SerializeField]
    private Citadel _citadel;

    [SerializeField]
    private Button _button1;

    [SerializeField]
    private Button _button2;

    [SerializeField]
    private Button _button3;

    [SerializeField]
    private Button _button4;

    [SerializeField]
    private float _radiusToIncrease = 1.5f;

    [SerializeField]
    private Tower _towerToBuildTest;


    private void Awake() {
        _citadel = Instantiate(_citadel, transform);
        _button1.onClick.AddListener(ChangeTowerRadiusInvoke);
        _button2.onClick.AddListener(UnlockSecondSlotInvoke);
        _button3.onClick.AddListener(BuildTowerInvoke);
    }

    private void ChangeTowerRadiusInvoke() {
        _citadel.ChangeTowersRadius(_radiusToIncrease);
    }

    private void UnlockSecondSlotInvoke() {
        _citadel.UnlockTowerSlot(2);
    }

    private void BuildTowerInvoke() {
        _citadel.AddTower(_towerToBuildTest);
    }
}