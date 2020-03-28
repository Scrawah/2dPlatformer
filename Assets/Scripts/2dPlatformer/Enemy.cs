using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    
    private Transform[] _points;
    private int _currentPoint;
    private bool _faceRight;
    private Animator _animator;

    private void Start()
    {
        _currentPoint = 0;
        _points = new Transform[_path.childCount];
        _animator = GetComponent<Animator>();

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        var direction = (target.position - transform.position).normalized;
        if ((direction.x > 0 && _faceRight) || (direction.x < 0 && !_faceRight))
        {
            Flip();
        }
        _animator.SetFloat("xSpeed", Mathf.Abs(direction.x));
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
    
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _faceRight = !_faceRight;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.Kill();
        }
    }
    
}
