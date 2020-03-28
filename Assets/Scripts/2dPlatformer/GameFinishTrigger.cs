using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFinishTrigger : MonoBehaviour
{
    [SerializeField] private Door _exit;
    
    private Coin[] _coins;

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in _coins)
        {
            coin.Reached += OnCoinGet;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            coin.Reached -= OnCoinGet;
        }
    }

    private void OnCoinGet()
    {
        foreach (var coin in _coins)
        {
            if (coin.IsReached == false)
                return;
        }
        
        _exit.Open();
    }
}
