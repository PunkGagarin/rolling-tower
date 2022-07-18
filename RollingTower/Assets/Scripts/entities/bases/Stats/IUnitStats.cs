using System.Collections.Generic;

namespace entities.bases.Stats {

    public interface IUnitStats<UST, US> {
        public Dictionary<UST, US> getAllStats();
        public US getStatByType(UST type);
    }

}