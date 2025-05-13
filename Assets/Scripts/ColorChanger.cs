using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        Change();
    }

    private void Change()
    {
        _material.color = new Color(Random.value, Random.value, Random.value, 255);
    }
}
