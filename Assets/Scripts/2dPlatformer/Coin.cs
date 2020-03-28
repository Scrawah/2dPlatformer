using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public bool IsReached { get; private set; }

    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsReached)
            return;
        
        if (other.TryGetComponent<Player>(out Player player))
        {
            IsReached = true;
            _reached?.Invoke();
        }
    }
}
