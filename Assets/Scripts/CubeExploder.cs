using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{

    [SerializeField] private int _explosionForceForObjectList = 200;
    [SerializeField] private int _explosionRadiusForObjectList = 10;

    [SerializeField] private float _explosionForceForAllObjects = 200;
    [SerializeField] private float _explosionRadiusForAllObjects = 10;

    public void Explode(Transform cubeTransform, List<Rigidbody> targets)
    {
        foreach (Rigidbody explodeTarget in targets)
        {
            explodeTarget.AddExplosionForce(_explosionForceForObjectList, cubeTransform.position, _explosionRadiusForObjectList);
        }
    }

    public void Explode(Cube cube)
    {
        foreach (var explodableObject in GetExplodableObjects(cube.transform))
        {
            explodableObject.AddExplosionForce(_explosionForceForAllObjects * cube.MultiplierValueOfSize, cube.transform.position, _explosionRadiusForAllObjects * cube.MultiplierValueOfSize);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Transform cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.position, _explosionRadiusForAllObjects);
        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
