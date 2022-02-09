using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetCounters : MonoBehaviour
{
    public event Action Reset = default;

    public void StartResetAction()
    {
        Reset();
    }
}
