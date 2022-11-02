using UnityEngine;

[System.Serializable]
public class GameObjectCreator<T> where T : MonoBehaviour{

    [SerializeField]
    private T _chooseResourcePanelPrefab;

    [SerializeField]
    private Transform _parent;

    public T CreatePanel() {
        var createdObject = Object.Instantiate(_chooseResourcePanelPrefab);
        if(_parent!=null)
            createdObject.transform.SetParent(_parent);
        return createdObject;
    }
}