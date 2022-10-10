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
        _plusButton.onClick.AddListener(ClickOnPlusWorkerButton);
        _minusButton.onClick.AddListener(ClickOnMinusWorkerButton);
        _workersCount.text = WorkersStartCountText;
        CheckOnZeroCount();
    }

    public void Init(ResourceType resourceType) {
        _resourceType = resourceType;
        _resourceIcon.sprite = _resourceIconFactory.GetResourceIconByType(_resourceType);
    }

    private void ClickOnPlusWorkerButton() {
        _workerOnThisResourceCount++;
        _workersCount.text = _workerOnThisResourceCount.ToString();
        CheckOnZeroCount();
        OnPlusButtonClicked?.Invoke();
    }

    private void ClickOnMinusWorkerButton() {
        _workerOnThisResourceCount--;
        _workersCount.text = _workerOnThisResourceCount.ToString();
        CheckOnZeroCount();
        OnMinusButtonClicked?.Invoke();
    }

    private void CheckOnZeroCount() {
        _minusButton.interactable = _workerOnThisResourceCount > 0;
    }

    public void SetPlusButtonInteractable(bool isAcive) {
        _plusButton.interactable = isAcive;
    }

    private void OnDestroy() {
        _plusButton.onClick.RemoveListener(ClickOnPlusWorkerButton);
        _minusButton.onClick.RemoveListener(ClickOnMinusWorkerButton);
    }

    public int workerCount => _workerOnThisResourceCount;
    public ResourceType resourceType => _resourceType;
}