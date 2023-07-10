using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> _onTimeValueSent;
    private float _startTime;
    private bool _isTimerRunning;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time - _startTime);
            string formattedTime = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
            _onTimeValueSent?.Invoke(formattedTime);
        }
    }

    private void StartTimer()
    {
        _startTime = Time.time;
        _isTimerRunning = true;
    }

    private void OnDestroy()
    {
        StopTimer();
    }

    public void StopTimer()
    {
        _isTimerRunning = false;
    }
}
