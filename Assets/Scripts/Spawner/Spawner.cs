using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeView _cube;
    [SerializeField] private int _capacity;
    private SpawnerModel _model;

    private ObjectPool<CubeView> _pool;
    private IEnumerator _spawn;

    private void Start()
    {
        _pool = new ObjectPool<CubeView>(CreateCube, _capacity);
        
        _spawn = SpawnCube();

        StartCoroutine(_spawn);
    }

    public void Init(SpawnerModel model)
    {
        _model = model;
    }
    
    private CubeView CreateCube()
    {
        var cube = Instantiate(_cube, transform.position, Quaternion.identity, transform);
        
        cube.Init(_model.Speed, _model.Distance, ReturnObject);
        
        cube.gameObject.SetActive(false);

        return cube;
    }

    private IEnumerator SpawnCube()
    {
        while (true)
        {
            yield return new WaitForSeconds(_model.SpawnDelay);
            var spawned = _pool.TakeObject();

            spawned.gameObject.SetActive(true);
        }
    }
    
    private void ReturnObject(CubeView cube)
    {
        _pool.ReturnToPool(cube);
    }
}
