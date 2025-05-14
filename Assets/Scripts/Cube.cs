using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private Material _material;

    public event Action<Cube> ClickedOnCube;

    public float ChanceToSplit { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }
    public bool IsSplitted { get; private set; }
    public float MultiplierValueOfSize { get; private set; } = 1f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
        _material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 255);
    }

    private void Start()
    {
        IsSplitted = CanToSplit();
    }

    public void DisableObject()
    {
        ClickedOnCube?.Invoke(this);
    }

    public void Initialize(float chanceToSplit, Vector3 scale, float multiplierValueOfSize)
    {
        float IncreaseMultiplierValue = 0.25f;
        MultiplierValueOfSize = multiplierValueOfSize + IncreaseMultiplierValue;
        ChanceToSplit = chanceToSplit;
        transform.localScale = scale;
    }

    private bool CanToSplit()
    {
        float minChanceToSplit = 0;
        float maxChanceToSplit = 100;
        float currentChance = UnityEngine.Random.Range(minChanceToSplit, maxChanceToSplit);

        return currentChance <= ChanceToSplit;
    }
}
