using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private const int MouseButtonIndex = 0;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButtonIndex))
        {
            CommandToExplode();
        }
    }

    private void CommandToExplode()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hit, Mathf.Infinity);

        if (_hit.collider.GetComponent<Cube>() == true)
        {
            _hit.collider.GetComponent<Cube>().Explode();
        }
    }
}
