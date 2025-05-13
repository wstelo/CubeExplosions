using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private InputService _inputService;
    [SerializeField] private CreatedCubesExploder _createrCubesExploder;
    [SerializeField] private OtherCubesExploder _otherCubesExploder;
    [SerializeField] private CubeDetector _raycaster;

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
        if (cube.IsSplitted)
        {
            _createrCubesExploder.Explode(cube, _spawner.Spawn(cube));
            _spawner.DestroyObject(cube);
        }
        else
        {
            _otherCubesExploder.Explode(cube);
            _spawner.DestroyObject(cube);
        }
    }
}
