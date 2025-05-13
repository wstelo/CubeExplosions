using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionForce = 200;
    [SerializeField] private int _explosionRadius = 10;

    public void Explode(Cube cube, List<Rigidbody> targets)
    {
        foreach (Rigidbody explodeTarget in targets)
        {
            explodeTarget.AddExplosionForce(_explosionForce, cube.transform.position,_explosionRadius);
        }
    }
}
