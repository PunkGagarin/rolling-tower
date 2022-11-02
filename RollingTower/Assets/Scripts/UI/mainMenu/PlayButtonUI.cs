using UnityEngine.SceneManagement;

namespace UI.mainMenu {

    public class PlayButtonUI : ButtonUI {

        protected override void ButtonAction() {
            SceneManager.LoadScene(1);
        }
    }

}