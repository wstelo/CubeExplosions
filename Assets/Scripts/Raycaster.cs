using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputService _inputService;

    private Ray _ray;
    private RaycastHit _hit;

    public event Action<Cube> TargetDetected;

    public void OnEnable()
    {
        _inputService.InputDetected += CommandToExplode;
    }

    public void OnDisable()
    {
        _inputService.InputDetected -= CommandToExplode;
    }

    private void CommandToExplode()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hit, Mathf.Infinity);

        if (_hit.collider.GetComponent<Cube>() == true)
        {
            TargetDetected?.Invoke(_hit.collider.GetComponent<Cube>());
        }
    }
}
