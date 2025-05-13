using System.Collections.Generic;
using UnityEngine;

public class EventInspector : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private InputService _inputService;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _inputService.TargetDetected += ExplodeObject;
    }

    private void OnDisable()
    {
        _inputService.TargetDetected -= ExplodeObject;
    }

    private void ExplodeObject(Cube cube)
    {
        if (TryToSplit(cube.ChanceToSplit))
        {
            _spawner.DestroyWithSplit(cube, out List<Cube> newCubes);
            _exploder.Explode(cube, newCubes);
            return;
        }

        _spawner.DestroyObject(cube);
    }

    private bool TryToSplit(float chanceToSplit)
    {
        float minChanceToSplit = 0;
        float maxChanceToSplit = 100;
        float currentChance = Random.Range(minChanceToSplit, maxChanceToSplit);

        if (currentChance <= chanceToSplit)
        {
            return true;
        }

        return false;
    }
}
