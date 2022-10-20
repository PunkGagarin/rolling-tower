using System;
using UnityEngine;

namespace gameSession.gathering {

    public class GatheringManager : MonoBehaviour, IStageManager {
        public Action OnGatheringFinish = delegate { };

        public static GatheringManager GetInstance { get; private set; }

        private void Awake() {
            if (GetInstance != null && GetInstance != this) {
                Destroy(this);
            } else {
                GetInstance = this;
            }
        }

        public void StartStage() {
            EndStage();
        }

        public void EndStage() {
            OnGatheringFinish.Invoke();
        }
    }

}