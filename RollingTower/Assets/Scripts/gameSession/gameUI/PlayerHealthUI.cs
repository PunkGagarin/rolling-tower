using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _healthText;

    public void ChangeHealthText(int currentHealth, int maxHealth) {
        _healthText.text = $"{currentHealth}/{maxHealth}";
    }

}