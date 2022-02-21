using UnityEngine;
using System;

public class CounterResetter : MonoBehaviour
{
    public event Action Reset = default;

    public void StartResetAction()
    {
        Reset();
    }
}
