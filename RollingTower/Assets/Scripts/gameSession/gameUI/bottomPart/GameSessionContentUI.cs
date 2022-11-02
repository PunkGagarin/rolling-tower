using UI;
using UnityEngine;

namespace gameSession.gameUI.bottomPart {

    public class GameSessionContentUI : AbstractScreen, IGetTabType {

        [field: SerializeField]
        public InGameTabType type { get; set; }
    }

}