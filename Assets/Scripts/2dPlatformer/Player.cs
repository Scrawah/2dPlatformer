using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public bool IsAlive { get; private set; }
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _whatIsGround;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private bool _faceRight;
    private bool _isGround;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        IsAlive = true;
        _faceRight = true;
    }

    private void Update()
    {
        _isGround = _rigidbody.velocity.y <= 0.05 && 
                    _rigidbody.velocity.y >= -0.05 && 
                    _rigidbody.Cast(Vector2.down, _whatIsGround, new RaycastHit2D[1], 0.1f) >= 1; 
        
        _animator.SetFloat("xSpeed", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat("ySpeed", _rigidbody.velocity.y);
        _animator.SetBool("isGround", _isGround);
    }
    
    public void Kill()
    {
        if(!IsAlive)
            return;

        IsAlive = false;
        _animator.SetTrigger("Death");

    }
    
    public void Jump()
    {
        if(!IsAlive)
            return;
        
        if (_isGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    
    public void Movement(float direction)
    {
        if(!IsAlive)
            return;

        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
        
        if ((_rigidbody.velocity.x > 0 && !_faceRight) || (_rigidbody.velocity.x < 0 && _faceRight))
        {
            Flip();
        }
        
        _animator.SetFloat("xSpeed", Mathf.Abs(_rigidbody.velocity.x));
    }
    
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _faceRight = !_faceRight;
    }

}
