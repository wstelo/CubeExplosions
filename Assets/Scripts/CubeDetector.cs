using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputService _inputService;

    private Ray _ray;
    private RaycastHit _hit;

    public void OnEnable()
    {
        _inputService.MouseButtonToRayDetected += DetectTarget;
    }

    public void OnDisable()
    {
        _inputService.MouseButtonToRayDetected -= DetectTarget;
    }

    private void DetectTarget()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hit, Mathf.Infinity);

        if (_hit.collider.TryGetComponent<Cube>(out Cube cube))
        {
            cube.DisableObject();
        }
    }
}
