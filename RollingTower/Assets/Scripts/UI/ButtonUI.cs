using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public abstract class ButtonUI : MonoBehaviour {

        private static string MyName = "asdf";

        private Button _button;

        private void Awake() 
        {
            _button = GetComponent<Button>();

            _button.onClick.AddListener(ButtonAction);
        }

        protected abstract void ButtonAction();

    }

}