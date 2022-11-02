using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningPopup : BaseScreen {
    private const string Warnign = "Warnign";
    private const string SomethingWentWrong = "Something went wrong";
    private const string Confirm = "Confirm";

    [Space] [SerializeField]
    private TextMeshProUGUI _warnignName;

    [Space] [SerializeField]
    private TextMeshProUGUI _warnignDescription;

    [SerializeField]
    private TextMeshProUGUI _warnignConfirmButtonText;

    [Space] [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private Button _confirmButton;

    public Action OnConfirmButtonPress = delegate { };

    public void ShowAndInitPopup(string warnignName = Warnign, string warnignDescription = SomethingWentWrong,
        string warnignConfirmButtonText = Confirm) {
        _warnignName.text = warnignName;
        _warnignDescription.text = warnignDescription;
        _warnignConfirmButtonText.text = warnignConfirmButtonText;
        Show();
    }

    private void Awake() {
        _exitButton.onClick.AddListener(Hide);
        _confirmButton.onClick.AddListener(ClickOnConfirmButton);
    }

    private void ClickOnConfirmButton() {
        OnConfirmButtonPress?.Invoke();
        Hide();
    }

    private void OnDestroy() {
        _exitButton.onClick.RemoveListener(Hide);
        _confirmButton.onClick.RemoveListener(ClickOnConfirmButton);
    }
}