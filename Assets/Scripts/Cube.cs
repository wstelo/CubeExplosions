using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _explosionForce = 200;
    [SerializeField] private int _explosionRadius = 10;
    
    private float _chanceToSplit = 100f;

    public void Explode()
    {
        if (TryToSplit())
        {
            CreateObjects();
        }

        Destroy(gameObject);
    }

    public void SetParameter(float chanceToSplit, Vector3 scale )
    {
        _chanceToSplit = chanceToSplit;
        transform.localScale = scale;
    }

    private void CreateObjects()
    {
        int minCloneCount = 2;
        int maxCloneCount = 6;
        int scaleCoefficient = 2;
        int splitDividerCoefficient = 2;
        int spawnAreaOffsetY = 1;
        float spawnRadius = 0.5f;
        int cloneCount = Random.Range(minCloneCount, maxCloneCount);

        for (int i = 0; i < cloneCount; i++)
        {
            Vector3 spawnArea = new Vector3(Random.Range(transform.position.x-spawnRadius,transform.position.x+spawnRadius), spawnAreaOffsetY, Random.Range(transform.position.z - spawnRadius, transform.position.z + spawnRadius));
            Cube newCube = Instantiate(_prefab, spawnArea,Quaternion.identity);
            newCube.SetParameter(_chanceToSplit/ splitDividerCoefficient, transform.localScale/ scaleCoefficient);
            newCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private bool TryToSplit()
    {
        float minChanceToSplit = 0;
        float maxChanceToSplit = 100;
        float currentChance = Random.Range(minChanceToSplit, maxChanceToSplit);

        if(currentChance <= _chanceToSplit)
        {
            return true;
        }

        return false;
    }
    
}
