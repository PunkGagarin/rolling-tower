using UnityEngine;

namespace gameSession.battle {

    public class PositionVectorUtils {
        public static Vector2 GetRandomPositionInTorus(float innerRadius, float wallRadius) {
            float rndAngle = Random.value * 6.28f; // use radians, saves converting degrees to radians

            // determine position
            float cX = Mathf.Sin(rndAngle);
            float cY = Mathf.Cos(rndAngle);

            Vector2 ringPos = new Vector2(cX, cY);
            ringPos *= innerRadius;

            // At any point around the center of the ring
            // a circle of radius the same as the wallRadius will fit exactly into the torus.
            // Simply get a random point in a sphere of radius wallRadius,
            // then add that to the random center point
            Vector2 sPos = Random.insideUnitCircle * wallRadius;

            return (ringPos + sPos);
        }

        public static Vector2 GetRandomPositionInGroup(Vector2 groupCenter, float groupRadius, float groupWallRadius) {
            float rndAngle = Random.value * 6.28f; // use radians, saves converting degrees to radians

            // determine position
            float cX = Mathf.Sin(rndAngle);
            float cY = Mathf.Cos(rndAngle);

            Vector2 ringPos = new Vector2(cX + groupCenter.x, cY + groupCenter.y);
            ringPos *= groupRadius;

            // At any point around the center of the ring
            // a circle of radius the same as the wallRadius will fit exactly into the torus.
            // Simply get a random point in a sphere of radius wallRadius,
            // then add that to the random center point
            Vector2 sPos = Random.insideUnitCircle * groupWallRadius;

            return (ringPos + sPos);
        }
    }

}