using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SecretRoom : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _volumeDelta;
    
    private AudioSource _audio;
    private bool _canPlay;
    
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_canPlay)
        {
            if (_audio.volume <= 0)
            {
                _audio.Play();
            }

            if (_audio.volume < _maxVolume)
            {
                _audio.volume += Time.deltaTime * _volumeDelta;
            }
        }
        else
        {
            _audio.volume -= Time.deltaTime * _volumeDelta;
            
            if (_audio.volume <= 0)
            {
                _audio.Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _canPlay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _canPlay = false;
        }
    }
}
