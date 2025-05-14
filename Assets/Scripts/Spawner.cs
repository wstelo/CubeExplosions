using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private CubeExploder _cubeExploder;
    [SerializeField] private int _minPositionX;
    [SerializeField] private int _maxPositionX;
    [SerializeField] private int _minPositionZ;
    [SerializeField] private int _maxPositionZ;
    [SerializeField] private int _positionY;
    [SerializeField] private int initialCubesCount = 4;

    private void Start()
    {
        SpawnInitialCubes();
    }

    private void SpawnInitialCubes()
    {
        for (int i = 0; i < initialCubesCount; i++)
        {
            Vector3 spawnArea = new Vector3(Random.Range(_minPositionX, _maxPositionX), _positionY, Random.Range(_minPositionZ, _maxPositionZ));
            Cube cube = Instantiate(_prefab, spawnArea, Quaternion.identity);
            cube.ClickedOnCube += ExplodeObject;
        }
    }

    public List<Rigidbody> Spawn(Cube cube)
    {
        int minCloneCount = 2;
        int maxCloneCount = 6;
        int scaleCoefficient = 2;
        int splitDividerCoefficient = 2;
        float spawnAreaOffsetY = 1.5f;
        float spawnRadius = 0.8f;
        int cloneCount = Random.Range(minCloneCount, maxCloneCount + 1);
        List<Rigidbody> newCubes = new List<Rigidbody>();

        for (int i = 0; i < cloneCount; i++)
        {
            Vector3 spawnArea = new Vector3(Random.Range(cube.transform.position.x - spawnRadius, cube.transform.position.x + spawnRadius), spawnAreaOffsetY, Random.Range(cube.transform.position.z - spawnRadius, cube.transform.position.z + spawnRadius));
            Cube newCube = Instantiate(_prefab, spawnArea, Quaternion.identity);
            newCube.Initialize(cube.ChanceToSplit / splitDividerCoefficient, cube.transform.localScale / scaleCoefficient, cube.MultiplierValueOfSize);
            newCubes.Add(newCube.Rigidbody);
            newCube.ClickedOnCube += ExplodeObject;
        }

        return newCubes;
    }

    private void ExplodeObject(Cube cube)
    {
        if (cube.IsSplitted)
        {
            _cubeExploder.Explode(cube.transform, Spawn(cube));
            Destroy(cube.gameObject);
        }
        else
        {
            _cubeExploder.Explode(cube);
            Destroy(cube.gameObject);
        }
    }
}
