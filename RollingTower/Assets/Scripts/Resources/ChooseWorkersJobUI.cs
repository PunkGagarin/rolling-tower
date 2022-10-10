using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWorkersJobUI : BaseScreen {
    private const string PopupNameText = "WARNING";
    private const string PopupDescription = "You still have free workers!";
    private const string ConfirmButtonText = "I understand";

    [SerializeField]
    private ResourceSourceHolder _resourceSourceHolder;

    [SerializeField]
    private GameObjectCreator<ChooseResourceToWorkerPanel> _gameObjectCreator;

    [SerializeField]
    private WarningPopup _warningPopup;

    [Space] [SerializeField]
    private TextMeshProUGUI _workerCountText;

    [SerializeField]
    private Image _workerIcon;

    [SerializeField]
    private Button _spawnWorkersButton;

    [Space] [SerializeField]
    private Color32 _offWorkerIconCount;

    private int _worketCount;

    private List<ResourceType> _resourcesToTake = new();
    public Action<List<ResourceType>> OnWorkerSpawnButtonClick = delegate { };
    private readonly List<ChooseResourceToWorkerPanel> _chooseResourcePanels = new();

    public void Init(int worketCount) {
        _worketCount = worketCount;
    }

    private void Awake() {
        _spawnWorkersButton.onClick.AddListener(ClickOnWorkerSpawnButton);
        _warningPopup.OnConfirmButtonPress += SpawnWorkersByCountAndType;
    }

    private void Start() {
        _workerCountText.text = _worketCount.ToString();
        var listOfResourceSource = _resourceSourceHolder.GetListOfResources();
        for (int i = 0; i < listOfResourceSource.Count; i++) {
            var panel = _gameObjectCreator.CreatePanel();
            _chooseResourcePanels.Add(panel);
            panel.Init(listOfResourceSource[i].resourceType);
            panel.OnPlusButtonClicked += PlusWokerToResouce;
            panel.OnMinusButtonClicked += MinusWokerFromResouce;
        }
    }

    private void ClickOnWorkerSpawnButton() {
        if (_worketCount > 0) {
            _warningPopup.ShowAndInitPopup(PopupNameText, PopupDescription, ConfirmButtonText);
        } else {
            SpawnWorkersByCountAndType();
        }
    }

    private void SpawnWorkersByCountAndType() {
        foreach (var panel in _chooseResourcePanels) {
            for (int i = 0; i < panel.workerCount; i++) {
                _resourcesToTake.Add(panel.resourceType);
            }
        }
        OnWorkerSpawnButtonClick?.Invoke(_resourcesToTake);
        _resourcesToTake.Clear();
        Hide();
    }

    private void PlusWokerToResouce() {
        _worketCount--;
        _workerCountText.text = _worketCount.ToString();
        CheckOnWorkerCountLeft();
    }

    private void MinusWokerFromResouce() {
        _worketCount++;
        _workerCountText.text = _worketCount.ToString();
        if (_worketCount == 1) {
            _workerIcon.color = Color.white;
            foreach (var panel in _chooseResourcePanels) {
                panel.SetPlusButtonInteractable(true);
            }
        }
    }

    private void CheckOnWorkerCountLeft() {
        if (_worketCount == 0) {
            _workerIcon.color = _offWorkerIconCount;
            foreach (var panel in _chooseResourcePanels) {
                panel.SetPlusButtonInteractable(false);
            }
        }
    }

    private void OnDestroy() {
        _spawnWorkersButton.onClick.RemoveListener(ClickOnWorkerSpawnButton);
        foreach (var panel in _chooseResourcePanels) {
            panel.OnPlusButtonClicked -= PlusWokerToResouce;
            panel.OnMinusButtonClicked -= MinusWokerFromResouce;
        }
    }
}