using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIResourceInGameHud : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private Image _resourceImage;

    public ResourceType type { get; private set; }

    public void SetResourceCount(float count) {
        _text.text = count.ToString();
    }

    public void Init(Sprite sprite, ResourceType type) {
        this.type = type;
        _resourceImage.sprite = sprite;
    }
}