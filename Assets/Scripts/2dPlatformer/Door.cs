using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _winBanner;
    
    private Animator _animator;
    private bool _isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isOpen = false;
    }

    public void Open()
    {
        _animator.SetTrigger("Open");
        _isOpen = true;
    }

    public void Close()
    {
        _animator.SetTrigger("Close");
        _isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isOpen && other.TryGetComponent<Player>(out Player player))
        {
            _winBanner.SetActive(true);
        }
    }
}
