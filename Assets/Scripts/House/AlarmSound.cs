using System;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private AudioSource _alarmAudio;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 0.25f;
    
    private float _minVolume = 0f;
    private bool _isActive = false;

    private void OnEnable()
    {
        if (_alarmAudio == null)
            return;
        
        _collisionDetector.OnIntruderEntered += SetAlarm;
    }

    private void Update()
    {
        if (_isActive)
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _maxVolume, _fadeSpeed * Time.deltaTime);
        else
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _minVolume, _fadeSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _collisionDetector.OnIntruderEntered -= SetAlarm;
    }
    
    private void SetAlarm(bool isEntered) => _isActive = isEntered;
}