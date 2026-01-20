using UnityEngine;

public class Sphere : MonoBehaviour
{
    private float _speed;
    private float _sphereLifeTime;
    private Vector3 _direction;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.velocity = _direction * _speed;
        Destroy(gameObject, _sphereLifeTime);
    }

    public void Setup(float speed, Ray direction, float sphereLifeTime)
    {
        _speed = speed;
        _direction = direction.direction;
        _sphereLifeTime = sphereLifeTime;
    }
}
