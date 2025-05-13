using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ChanceToSplit { get; private set; } = 100f;

    public void SetParameter(float chanceToSplit, Vector3 scale )
    {
        ChanceToSplit = chanceToSplit;
        transform.localScale = scale;
    } 
}
