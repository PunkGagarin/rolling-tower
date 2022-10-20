using System;
using UnityEngine;

namespace UI {

    public abstract class AbstractScreen : MonoBehaviour {
        private Action OnScreenShowed { get; set; }

        [SerializeField]
        protected GameObject _content;

        public void Show(AbstractScreen hideScreen = null) {
            if (hideScreen != null) hideScreen.Hide();
            ShowSelf();
        }

        private void ShowSelf() {
            _content.SetActive(true);
            OnScreenShowed?.Invoke();
        }

        protected void Hide() => _content.SetActive(false);

        protected virtual void Awake() => Hide();
    }

}