using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private float _pushForce = 10f;
    [SerializeField] private float _maxDistance = 40f;
    [SerializeField] private LayerMask _pushableLayerMask;
    [SerializeField] private GameObject _bulletHolePrefab;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(mousePos, out RaycastHit hit, _maxDistance, _pushableLayerMask))
            {
                if(hit.collider.TryGetComponent<Rigidbody>(out var rb))
                {
                    Debug.Log("Push");

                    GameObject bulletHole = Instantiate(_bulletHolePrefab, hit.point - _offset, Quaternion.LookRotation(-hit.normal), hit.transform);
                    bulletHole.transform.localScale = Vector3.one / hit.transform.localScale.x;
                    rb.AddForceAtPosition(mousePos.direction * _pushForce, hit.point, ForceMode.Impulse);
                }
            }
        }
    }
}
