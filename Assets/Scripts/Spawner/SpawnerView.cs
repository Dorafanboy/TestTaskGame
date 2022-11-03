using System;
using TMPro;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _spawnDelay;
    [SerializeField] private TMP_InputField _speed;
    [SerializeField] private TMP_InputField _distance;

    public event Action<float> SpawnDelayChanged;
    public event Action<float> SpeedChanged;
    public event Action<float> DistanceChanged;

    private void OnEnable()
    {
        _spawnDelay.onValueChanged.AddListener(OnSpawnDelayChanged);
        _speed.onValueChanged.AddListener(OnSpeedChanged);
        _distance.onValueChanged.AddListener(OnDistanceChanged);
    }

    private void OnDisable()
    {
        _spawnDelay.onValueChanged.RemoveListener(OnSpawnDelayChanged);
        _speed.onValueChanged.RemoveListener(OnSpeedChanged);
        _distance.onValueChanged.RemoveListener(OnDistanceChanged);
    }

    private void OnSpawnDelayChanged(string value)
    {
        if (float.TryParse(value, out var newValue))
        {
            SpawnDelayChanged?.Invoke(newValue);
        }
    }

    private void OnSpeedChanged(string value)
    {
        if (float.TryParse(value, out var newValue))
        {
            SpeedChanged?.Invoke(newValue);
        }
    }

    private void OnDistanceChanged(string value)
    {
        if (float.TryParse(value, out var newValue))
        {
            DistanceChanged?.Invoke(newValue);
        }
    }
}
