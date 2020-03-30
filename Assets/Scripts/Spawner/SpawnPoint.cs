using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _path;

    public void Spawn()
    {
        var obj = Instantiate(_enemyPrefab);
        obj.transform.position = transform.position;
        obj.SetPath(_path);
    }
}
