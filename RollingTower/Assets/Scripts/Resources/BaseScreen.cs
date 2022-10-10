using UnityEngine;

public class BaseScreen : MonoBehaviour {
    [SerializeField]
    private GameObject _content;

    public virtual void Show() {
        _content.SetActive(true);
    }

    public virtual void Hide() {
        _content.SetActive(false);
    }
}