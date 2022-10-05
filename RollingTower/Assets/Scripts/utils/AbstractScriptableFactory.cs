using System.Collections.Generic;
using UnityEngine;

namespace utils {


    public abstract class AbstractScriptableFactory<S, T> : MonoBehaviour where S : ScriptableObject {

        [SerializeField]
        private string _resourcePath;

        [SerializeField]
        protected List<S> _objects;

        public static AbstractScriptableFactory<S, T> GetInstance { get; private set; }

        protected void Awake() {
            if (GetInstance == null) {
                GetInstance = this;
            }
            _objects.AddRange(Resources.LoadAll<S>(_resourcePath));
        }

        public abstract S GetByType(T type);
    }
}