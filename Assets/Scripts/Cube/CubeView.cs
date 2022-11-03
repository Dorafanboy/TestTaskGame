using System;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    private float _speed;
    private float _direction;
    
    private Action<CubeView> _backToPool;

    public void Init(float speed, float direction, Action<CubeView> backToPool)
    {
        _speed = speed;
        _direction = direction;
        _backToPool = backToPool;
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,GetTargetPosition(), 
            _speed * Time.deltaTime);

        if (transform.position.x == _direction)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        gameObject.SetActive(false);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        _backToPool(this);
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(_direction, transform.position.y, transform.position.z);
    }
}
