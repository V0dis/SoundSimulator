using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudio;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 0.25f;
    
    private float _targetVolume;
    private float _minVolume = 0f;
    private bool _isActive = false;
    private Coroutine _fadeSound;

    private void Awake()
    {
        if (_alarmAudio == null)
            return;
    }

    public void SetAlarm(bool isEntered)
    {
        _isActive = isEntered;
        _targetVolume = _isActive ? _maxVolume : _minVolume;
        
        if (_fadeSound != null)
            return;
        
        _fadeSound = StartCoroutine(FadeSound());
    }

    private IEnumerator FadeSound()
    {
        while (Mathf.Approximately(_alarmAudio.volume, _targetVolume) == false)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            
            yield return null;
        }

        _fadeSound = null;
    }
}