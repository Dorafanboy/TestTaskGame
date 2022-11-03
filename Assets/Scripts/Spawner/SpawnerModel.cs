public class SpawnerModel
{
    public float SpawnDelay { get; private set; }
    public float Speed { get; private set; }
    public float Distance { get; private set; }

    public SpawnerModel(float spawnDelay, float speed, float distance)
    {
        SpawnDelay = spawnDelay;
        Speed = speed;
        Distance = distance;
    }

    public void ChangeSpawnDelay(float value)
    {
        SpawnDelay = InstallValue(value) == 0 ? SpawnDelay : InstallValue(value);
    }
    
    public void ChangeSpeed(float value)
    {
        Speed = InstallValue(value) == 0 ? Speed : InstallValue(value);
    }
    
    public void ChangeDistance(float value)
    {
        Distance = InstallValue(value) == 0 ? Distance : InstallValue(value);
    }

    private float InstallValue(float newValue)
    {
        return newValue < 0 ? 0 : newValue;
    }
}
