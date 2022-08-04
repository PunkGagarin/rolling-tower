using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace gameSession.factories {

    public class AbstractPrefabFactory<P, T> : MonoBehaviour where P : MonoBehaviour, IType<T>  {
        
        //todo: rework with adressables later
        protected List<P> _prefabs;
    
        [SerializeField]
        private string _resourcePath;
        
        public static AbstractPrefabFactory<P, T> GetInstance { get; private set; }

        private void Awake() {
            if (GetInstance == null) {
                GetInstance = this;
            }
            _prefabs = Resources.LoadAll<P>(_resourcePath).ToList();
        }
        
        public P GetPrefabByType(T type) {
            if (IsPrefabExists(type)) {
                return FindPrefab(type);
            } else {
                Debug.Log("Trying to get not existed enemy!");
                throw new ArgumentException("Enemy not exists!");
            }
        }

        private P FindPrefab(T type) {
            return _prefabs.Find(prefab => prefab.getType().Equals(type));
        }

        private bool IsPrefabExists(T type) {
            return _prefabs.Exists(prefab => prefab.getType().Equals(type));
        }
    }

}