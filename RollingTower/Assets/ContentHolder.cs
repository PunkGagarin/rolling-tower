using System.Collections.Generic;
using System.Linq;
using gameSession.gameUI.bottomPart;
using UnityEngine;

public class ContentHolder : MonoBehaviour {


    [SerializeField]
    private List<GameSessionContentUI> _contents;

    private void Awake() {
        _contents = GetComponentsInChildren<GameSessionContentUI>().ToList();
    }

    public void ChangeContentTabByType(InGameTabType type) {
        
        foreach (var content in _contents) {
            if (type.Equals(content.type)) {
                Debug.Log("Showing content with type: " + content.type);
                content.Show();
            } else {
                content.Hide();
                Debug.Log("trying to Hide content of : " + content.type);
            }
        }
    }
}