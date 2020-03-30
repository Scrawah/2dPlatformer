using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _respawnTime;

    private float _currentTime;

    private int _currentPoint;
    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new SpawnPoint[transform.childCount];
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        _currentTime = 0;
        _currentPoint = 0;
    }

    private void Update()
    {
        if (_currentTime > _respawnTime)
        {
            _spawnPoints[_currentPoint].Spawn();
            _currentPoint++;

            if (_currentPoint >= _spawnPoints.Length)
            {
                _currentPoint = 0;
            }

            _currentTime = 0;
        }

        _currentTime += Time.deltaTime;
    }
}
