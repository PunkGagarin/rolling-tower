using UnityEngine;

namespace UI.mainMenu {

    public class QuitButton : ButtonUI {
        protected override void ButtonAction() {
            Debug.Log("App quit");
            Application.Quit();
        }

    }

}