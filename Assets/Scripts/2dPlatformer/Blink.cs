using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Blink : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;
    [SerializeField] private bool _loop;
    
    private SpriteRenderer _sprite;
    private float _runningTime;
    private Color _originalColor;
    
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _originalColor = _sprite.color;
    }
    
    void Update()
    {
        if (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;

            var normalizeRunningTime = _runningTime / _duration;
            
            _sprite.color = Color.Lerp(_originalColor, _targetColor, normalizeRunningTime);
        }
        else if (_loop)
        {
            _sprite.color = _originalColor;
            _runningTime = 0;
        }
    }
}
