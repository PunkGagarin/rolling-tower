using System;
using System.Collections.Generic;
using entities.enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    public Action OnWaveClear = delegate { };

    private float _innerRadius;

    private GameSessionManager _gameSessionManager;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _leftSide = 19.5f;

    [SerializeField]
    private float _topSide = 15f;

    [SerializeField]
    private float _wallRadius = 1.5f;

    private HashSet<Enemy> _enemies;

    public static EnemySpawner GetInstance { private set; get; }

    private void Awake() {
        if (GetInstance == null)
            GetInstance = this;
    }

    private void Start() {
        _gameSessionManager = GameSessionManager.GetInstance;
        _innerRadius = (Vector2.left * _leftSide + Vector2.up * _topSide).magnitude;
    }

    private void SpawnWave(EnemyWave wave) {
    }


    private Vector2 GetRandomPositionInTorus() {
        float rndAngle = Random.value * 6.28f; // use radians, saves converting degrees to radians

        // determine position
        float cX = Mathf.Sin(rndAngle);
        float cY = Mathf.Cos(rndAngle);

        Vector2 ringPos = new Vector2(cX, cY);
        ringPos *= _innerRadius;

        // At any point around the center of the ring
        // a circle of radius the same as the wallRadius will fit exactly into the torus.
        // Simply get a random point in a sphere of radius wallRadius,
        // then add that to the random center point
        Vector2 sPos = Random.insideUnitCircle * _wallRadius;

        return (ringPos + sPos);
    }


}