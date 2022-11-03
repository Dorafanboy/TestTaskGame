public class SpawnerPresenter
{
    private readonly SpawnerView _view;
    private readonly SpawnerModel _model;

    public SpawnerPresenter(SpawnerView view, SpawnerModel model)
    {
        _view = view;
        _model = model;
    }
    
    public void Enable()
    {
        _view.SpawnDelayChanged += OnSpawnDelayChanged;
        _view.SpeedChanged += OnSpeedChanged;
        _view.DistanceChanged += OnDistanceChanged;
    }

    public void Disable()
    {
        _view.SpawnDelayChanged -= OnSpawnDelayChanged;
        _view.SpeedChanged -= OnSpeedChanged;
        _view.DistanceChanged -= OnDistanceChanged;
    }

    private void OnSpawnDelayChanged(float value)
    {
        _model.ChangeSpawnDelay(value);
    }
    
    private void OnSpeedChanged(float value)
    {
        _model.ChangeSpeed(value);
    }
    
    private void OnDistanceChanged(float value)
    {
       _model.ChangeDistance(value); 
    }
}
