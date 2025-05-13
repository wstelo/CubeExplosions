using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material _material;

    public float ChanceToSplit { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }
    public bool IsSplitted { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
        Change();
    }

    private void Start()
    {
        IsSplitted = TryToSplit();
    }

    private void Change()
    {
        _material.color = new Color(Random.value, Random.value, Random.value, 255);
    }

    private bool TryToSplit()
    {
        float minChanceToSplit = 0;
        float maxChanceToSplit = 100;
        float currentChance = Random.Range(minChanceToSplit, maxChanceToSplit);

        return currentChance <= ChanceToSplit;
    }

    public void SetParameter(float chanceToSplit, Vector3 scale)
    {
        ChanceToSplit = chanceToSplit;
        transform.localScale = scale;
    }
}
