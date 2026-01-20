using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private Sphere _spherePrefab;
    [SerializeField] private float _sphereSpeed;
    [SerializeField] private float _sphereLifeTime = 3f;
    [SerializeField] private float _maxDistance = 50f;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePos = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.SphereCast(mousePos, _radius, _maxDistance, _wallLayer))
            {
                Debug.Log($"Cannot throw a sphere. A grey wall is in the way!");
            }
            else
            {
                Sphere sphere = Instantiate(_spherePrefab);
                sphere.transform.position = transform.position;
                sphere.Setup(_sphereSpeed, mousePos, _sphereLifeTime);
            }
        }
    }

}
