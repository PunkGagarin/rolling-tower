using System;

public class MoveFactory {
    
    public static AbstractMovement GetMoveBehaviour(EnemyMoveType type) {
        switch (type) {
            case EnemyMoveType.ToClosestTarget:
                return new SimpleStraightMoveBehaviour(); 
        }
        throw new ArgumentException();
    }
}