using UnityEngine;

public class VectorProjectileDto : AbstractProjectileDTO {

    public VectorProjectileDto(IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier) : base(damageDealer, targetLayer, moveSpeedMultiplier) {
        //nothing    
    }
}