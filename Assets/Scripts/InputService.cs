using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const int MouseButtonIndex = 0;

    public event Action LeftMouseButtonInputDetected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButtonIndex))
        {
            LeftMouseButtonInputDetected?.Invoke();
        }
    }
}
