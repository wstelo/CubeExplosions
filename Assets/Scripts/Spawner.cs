using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    public void DestroyWithSplit(Cube cube, out List<Cube> newCubes)
    {
        int minCloneCount = 2;
        int maxCloneCount = 6;
        int scaleCoefficient = 2;
        int splitDividerCoefficient = 2;
        float spawnAreaOffsetY = 1.5f;
        float spawnRadius = 0.8f;
        int cloneCount = Random.Range(minCloneCount, maxCloneCount);
        newCubes = new List<Cube>();

        for (int i = 0; i < cloneCount; i++)
        {
            Vector3 spawnArea = new Vector3(Random.Range(cube.transform.position.x - spawnRadius, cube.transform.position.x + spawnRadius), spawnAreaOffsetY, Random.Range(cube.transform.position.z - spawnRadius, cube.transform.position.z + spawnRadius));
            Cube newCube = Instantiate(_prefab, spawnArea, Quaternion.identity);
            newCube.SetParameter(cube.ChanceToSplit / splitDividerCoefficient, cube.transform.localScale / scaleCoefficient);
            newCubes.Add(newCube);
            Debug.Log(newCube.ChanceToSplit);
        }

        GameObject.Destroy(cube.gameObject);
    }

    public void DestroyObject(Cube cube)
    {
        GameObject.Destroy(cube.gameObject);
    }
}
