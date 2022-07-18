using System;

public class AttackTypeFactory {
    public static AbstractUnitAttack GetAttackBehaviourByType(AttackType attackType) {
        switch (attackType) {
            case AttackType.Melee:
                return new MeleeAttackBehaviour();
            case AttackType.Range:
                return new RangeAttackBehaviour();
        }
        throw new ArgumentException();
    }
}