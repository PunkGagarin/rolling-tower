using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWorkersJobUIView : MonoBehaviour{
    private const string PopupNameText = "WARNING";
    private const string PopupDescription = "You still have free workers!";
    private const string ConfirmButtonText = "I understand";

    private Action ClickOnPopupConfirmButtonCallBack;

    [SerializeField]
    private WarningPopup _warningPopup;

    [Space] [SerializeField]
    private TextMeshProUGUI _workerCountText;

    [SerializeField]
    private Image _workerIcon;

    [Space] [SerializeField]
    private Color32 _offWorkerIconCount;

    public void Init(Action callBack) {
        ClickOnPopupConfirmButtonCallBack = callBack;
        _warningPopup.OnConfirmButtonPress += ClickOnPopupConfirmButtonCallBack;
    }

    public void SetWorkerCount(float count) {
        _workerCountText.text = count.ToString();
        if (count > 0) {
            _workerIcon.color = Color.white;
        } else {
            _workerIcon.color = _offWorkerIconCount;
        }
    }

    public void ShopPopup() {
        _warningPopup.ShowAndInitPopup(PopupNameText, PopupDescription, ConfirmButtonText);
    }

    private void OnDestroy() {
        _warningPopup.OnConfirmButtonPress -= ClickOnPopupConfirmButtonCallBack;
    }
}