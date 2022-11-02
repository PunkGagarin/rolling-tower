using System;
using UnityEngine;

namespace UI {

    public abstract class AbstractScreen : MonoBehaviour {
        private Action OnScreenShowed { get; set; }

        protected GameObject _content;

        public void Show(AbstractScreen hideScreen = null) {
            if (hideScreen != null) hideScreen.Hide();
            ShowSelf();
        }

        private void ShowSelf() {
            _content.SetActive(true);
            OnScreenShowed?.Invoke();
        }

        public void Hide() => _content.SetActive(false);

        protected virtual void Awake() {
            _content = transform.Find("Content").gameObject;
            Hide();
        }
    }

}