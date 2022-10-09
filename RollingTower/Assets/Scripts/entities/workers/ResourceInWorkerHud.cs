using UnityEngine;
using UnityEngine.UI;

public class ResourceInWorkerHud : MonoBehaviour {
    [SerializeField]
    private Image _image;

    [SerializeField]
    protected Color32 _glowColor;
    
    [SerializeField]
    protected Color32 _unGlowColor;

    public void SetImage(Sprite icon) {
        _image.sprite = icon;
    }

    public void SetActivity(bool activity) {
        //todo: get color from config
        _image.color = activity ? _glowColor : _unGlowColor;
    }
}