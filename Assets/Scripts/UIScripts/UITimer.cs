using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Text counterSeconds;
    [SerializeField] private ResetCounters resetScript;

    private float timeInSeconds;

    private void OnEnable()
    {
        resetScript.Reset += ResetTimer;
    }

    private void OnDisable()
    {
        resetScript.Reset += ResetTimer;
    }

    private void ResetTimer()
    {
        timeInSeconds = 0;
    }

    private void Update()
    {
        timeInSeconds += Time.deltaTime;
        int secondsNumber = (int)(timeInSeconds % 60);

        counterSeconds.text = secondsNumber.ToString();
    }
}
