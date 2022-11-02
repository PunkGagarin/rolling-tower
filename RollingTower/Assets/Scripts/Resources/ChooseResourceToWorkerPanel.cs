using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseResourceToWorkerPanel : MonoBehaviour {
    private const string WorkersStartCountText = "0";

    [SerializeField]
    private ResourceIconFactory _resourceIconFactory;

    [Space] [SerializeField]
    private Button _plusButton;

    [SerializeField]
    private Button _minusButton;

    [SerializeField]
    private TextMeshProUGUI _workersCount;

    [SerializeField]
    private Image _resourceIcon;

    private ResourceType _resourceType;
    private int _workerOnThisResourceCount;

    public Action OnPlusButtonClicked = delegate { };
    public Action OnMinusButtonClicked = delegate { };

    private void Awake() {
        _plusButton.onClick.AddListener(PlusWorkerOnResource);
        _minusButton.onClick.AddListener(MinusWorkerOnResource);
        _workersCount.text = WorkersStartCountText;
        SwitchButtonInteractableBasedOnWorkersCount();
    }

    public void Init(ResourceType resourceType) {
        _resourceType = resourceType;
        _resourceIcon.sprite = _resourceIconFactory.GetResourceIconByType(_resourceType);
    }

    private void PlusWorkerOnResource() {
        _workerOnThisResourceCount++;
        _workersCount.text = _workerOnThisResourceCount.ToString();
        SwitchButtonInteractableBasedOnWorkersCount();
        OnPlusButtonClicked?.Invoke();
    }

    private void MinusWorkerOnResource() {
        _workerOnThisResourceCount--;
        _workersCount.text = _workerOnThisResourceCount.ToString();
        SwitchButtonInteractableBasedOnWorkersCount();
        OnMinusButtonClicked?.Invoke();
    }

    private void SwitchButtonInteractableBasedOnWorkersCount() {
        _minusButton.interactable = _workerOnThisResourceCount > 0;
    }

    public void SetPlusButtonInteractable(bool isAcive) {
        _plusButton.interactable = isAcive;
    }

    private void OnDestroy() {
        _plusButton.onClick.RemoveListener(PlusWorkerOnResource);
        _minusButton.onClick.RemoveListener(MinusWorkerOnResource);
    }

    public int workerCount => _workerOnThisResourceCount;
    public ResourceType resourceType => _resourceType;
}