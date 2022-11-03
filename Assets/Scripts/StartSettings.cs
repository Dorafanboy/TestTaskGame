using UnityEngine;

[CreateAssetMenu(fileName = "CubeSpawnerSettings", menuName = "StartSettings/CubeSpawnerSettings")]
public class StartSettings : ScriptableObject
{
    public float SpawnDelay;
    public float Speed;
    public float Direction;
}
