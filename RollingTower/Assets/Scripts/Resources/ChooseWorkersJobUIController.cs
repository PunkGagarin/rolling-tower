using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWorkersJobUIController : BaseScreen {

    public Action<List<ResourceType>> OnWorkerSpawnButtonClick = delegate { };

    [SerializeField]
    private GameObjectCreator<ChooseResourceToWorkerPanel> _gameObjectCreator;
    
    [SerializeField]
    private Button _spawnWorkersButton;

    [SerializeField]
    private ChooseWorkersJobUIView _view;

    private int _workerCount;

    private readonly List<ChooseResourceToWorkerPanel> _chooseResourcePanels = new();

    private ResourceSourceHolder _resourceSourceHolder;

    public void Init(int workerCount) {
        _workerCount = workerCount;
    }

    private void Awake() {
        _spawnWorkersButton.onClick.AddListener(ClickOnWorkerSpawnButton);
        _view.Init(SpawnWorkersByCountAndType);
    }

    private void Start() {
        _resourceSourceHolder = ResourceSourceHolder.GetInstance;
        _view.SetWorkerCount(_workerCount);
        var listOfResourceSource = _resourceSourceHolder.GetResourcesType();
        foreach (var resourvceType in listOfResourceSource) {
            var panel = _gameObjectCreator.CreatePanel();
            _chooseResourcePanels.Add(panel);
            panel.Init(resourvceType);
            panel.OnPlusButtonClicked += PlusWokerToResouce;
            panel.OnMinusButtonClicked += MinusWokerFromResouce;
        }
    }

    private void ClickOnWorkerSpawnButton() {
        if (_workerCount > 0) {
            _view.ShopPopup();
        } else {
            SpawnWorkersByCountAndType();
        }
    }

    private void SpawnWorkersByCountAndType() {
        List<ResourceType> _resourcesToTake = new();
        foreach (var panel in _chooseResourcePanels) {
            for (int i = 0; i < panel.workerCount; i++) {
                _resourcesToTake.Add(panel.resourceType);
            }
        }
        OnWorkerSpawnButtonClick?.Invoke(_resourcesToTake);
        Hide();
    }

    private void PlusWokerToResouce() {
        _workerCount--;
        _view.SetWorkerCount(_workerCount);
        CheckOnWorkerCountLeft();
    }

    private void MinusWokerFromResouce() {
        _workerCount++;
        _view.SetWorkerCount(_workerCount);
        if (_workerCount == 1) {
            foreach (var panel in _chooseResourcePanels) {
                panel.SetPlusButtonInteractable(true);
            }
        }
    }

    private void CheckOnWorkerCountLeft() {
        if (_workerCount == 0) {
            _view.SetWorkerCount(_workerCount);
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