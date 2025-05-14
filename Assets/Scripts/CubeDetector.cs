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
        Cube currentObject = _hit.collider.GetComponent<Cube>();

        if (currentObject != null)
        {
            TargetDetected?.Invoke(currentObject);
        }
    }
}
