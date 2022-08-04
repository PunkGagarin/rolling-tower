using System;
using System.Collections.Generic;
using UnityEngine;

public class CardChoosingUI : MonoBehaviour {

    public Action OnCardChoose = delegate { };

    private List<SkillCardUI> _cards = new();

    public static CardChoosingUI GetInstance { get; private set; }

    private void Awake() {
        if (GetInstance == null) {
            GetInstance = this;
        }
        _cards.AddRange(GetComponentsInChildren<SkillCardUI>());
        foreach (var cardUI in _cards) {
            cardUI.OnCardChoose += CardChooseHandler;
        }
        gameObject.SetActive(false);
    }

    private void CardChooseHandler(SkillCardUI obj) {
        OnCardChoose.Invoke();
        gameObject.SetActive(false);
    }
}