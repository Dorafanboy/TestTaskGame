using UnityEngine;

public class SpawnerSetup : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private SpawnerView _view;
    [SerializeField] private StartSettings _settings;
    
    private SpawnerModel _model;
    private SpawnerPresenter _presenter;

    private void Awake()
    {
        _model = new SpawnerModel(_settings.SpawnDelay, _settings.Speed, _settings.Direction);

        _presenter = new SpawnerPresenter(_view, _model);
        
        _spawner.Init(_model);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
