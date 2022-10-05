using System;
using entities.player.towers;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardUI : MonoBehaviour {

    public Action<SkillCardUI> OnCardChoose = delegate { };

    private Tower _towerToChoosePrefab;

    private Button _cardButton;

    private void Awake() {

        _cardButton = GetComponent<Button>();
        _cardButton.onClick.AddListener(ChooseTowerToBuild);
    }

    private void ChooseTowerToBuild() {
        OnCardChoose.Invoke(this);
    }
}