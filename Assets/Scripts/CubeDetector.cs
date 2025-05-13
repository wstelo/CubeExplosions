using System;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputService _inputService;

    private Ray _ray;
    private RaycastHit _hit;

    public event Action<Cube> TargetDetected;

    public void OnEnable()
    {
        _inputService.LeftMouseButtonInputDetected += CommandToExplode;
    }

    public void OnDisable()
    {
        _inputService.LeftMouseButtonInputDetected -= CommandToExplode;
    }

    private void CommandToExplode()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hit, Mathf.Infinity);

        if (_hit.collider.GetComponent<Cube>() !=null)
        {
            TargetDetected?.Invoke(_hit.collider.GetComponent<Cube>());
        }
    }
}
