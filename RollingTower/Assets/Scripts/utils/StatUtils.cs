using System;
using System.ComponentModel;
using enums.citadels;
using enums.towers;

namespace utils {

    public class StatUtils {
        public static TowerStatType ConvertCitadelTypeToTower(CitadelStatType type) {
            string citadelType = type.ToString();
            if (Enum.TryParse(citadelType, out TowerStatType typeToReturn)) {
                return typeToReturn;
            } else {
                throw new InvalidEnumArgumentException("Citadel type doesnt match with Tower type!");
            }
        }
        
        
        public static CitadelStatType ConvertTowerTypeToCitadel(TowerStatType type) {
            string towerStatType = type.ToString();
            if (Enum.TryParse(towerStatType, out CitadelStatType typeToReturn)) {
                return typeToReturn;
            } else {
                throw new InvalidEnumArgumentException("Citadel type doesnt match with Tower type!");
            }
        }     
        
        
        //play with this later
        public static T ConvertStatType<CT, T>(CT typeToConvert) where T : struct {
            string convertedTypeString = typeToConvert.ToString();
            if (Enum.TryParse(convertedTypeString, out T typeToReturn)) {
                return typeToReturn; 
            } else {
                throw new InvalidEnumArgumentException("Citadel type doesnt match with Tower type!");
            }
        }
    }

}