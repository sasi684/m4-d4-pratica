using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private float _pushForce = 10f;
    [SerializeField] private float _maxDistance = 40f;
    [SerializeField] private LayerMask _pushableLayerMask;

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
                    Vector3 push = mousePos.direction * _pushForce;

                    rb.AddForceAtPosition(push, hit.point, ForceMode.Impulse);
                }
            }
        }
    }
}
