using System;
using UnityEngine;

public class CardChoosingManager : MonoBehaviour {
    
    public Action OnCardChoose = delegate { };
    
    private CardChoosingUI _cardChoosingUI;

    private void Start() {
        _cardChoosingUI = CardChoosingUI.GetInstance;
        _cardChoosingUI.OnCardChoose += EndCardChoosing;
    }

    public void ActivateCardChoosingStage() {
        _cardChoosingUI.gameObject.SetActive(true);
    }

    public void EndCardChoosing() {
        OnCardChoose.Invoke();
    }
}