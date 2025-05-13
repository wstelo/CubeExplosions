using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private InputService _inputService;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.TargetDetected += ExplodeObject;
    }

    private void OnDisable()
    {
        _raycaster.TargetDetected -= ExplodeObject;
    }

    private void ExplodeObject(Cube cube)
    {
        if (cube.IsSplitted == true)
        {
            List<Rigidbody> newCubes = new List<Rigidbody>();
            newCubes = _spawner.Spawn(cube);
            _exploder.Explode(cube, newCubes);
        }

        _spawner.DestroyObject(cube);
    }
}
