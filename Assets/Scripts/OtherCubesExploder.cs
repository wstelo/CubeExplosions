using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCubesExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    public void Explode(Cube cube)
    {
        foreach (var explodableObject in GetExplodableObjects(cube.transform))
        {
            explodableObject.AddExplosionForce(_explosionForce * cube.MultiplierValueOfSize, cube.transform.position, _explosionRadius * cube.MultiplierValueOfSize);
            Debug.Log($"Force - {_explosionForce * cube.MultiplierValueOfSize}, Radius - {_explosionRadius * cube.MultiplierValueOfSize}");
        }        
    }

    private List<Rigidbody> GetExplodableObjects(Transform cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.position, _explosionRadius);

        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}
