using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private AudioSource _alarmAudio;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 0.25f;
    
    private float _targetVolume;
    private float _minVolume = 0f;
    private bool _isActive = false;
    private Coroutine _fadeSound;

    private void OnEnable()
    {
        if (_alarmAudio == null)
            return;
        
        _collisionDetector.IntruderEntered += SetAlarm;
    }

    private void OnDisable()
    {
        _collisionDetector.IntruderEntered -= SetAlarm;
    }
    
    private void SetAlarm(bool isEntered)
    {
        _isActive = isEntered;
        _targetVolume = _isActive ? _maxVolume : _minVolume;
        
        if (_fadeSound != null)
            return;
        
        _fadeSound = StartCoroutine(FadeSound());
    }

    private IEnumerator FadeSound()
    {
        if (_alarmAudio.isPlaying == false)
            _alarmAudio.Play();
        
        while (Mathf.Approximately(_alarmAudio.volume, _targetVolume) == false)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            
            yield return null;
        }
        
        if (Mathf.Approximately(_alarmAudio.volume, _minVolume))
            _alarmAudio.Stop();

        _fadeSound = null;
    }
}