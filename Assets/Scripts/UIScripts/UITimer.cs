using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Text _counterSeconds;
    [SerializeField] private CounterResetter _resetScript;

    private float _timeInSeconds;

    private void OnEnable()
    {
        _resetScript.Reset += ResetTimer;
    }

    private void OnDisable()
    {
        _resetScript.Reset += ResetTimer;
    }

    private void ResetTimer()
    {
        _timeInSeconds = 0;
    }

    private void Update()
    {
        _timeInSeconds += Time.deltaTime;
        int secondsNumber = (int)(_timeInSeconds % 60);

        _counterSeconds.text = "Времени прошло: " + secondsNumber.ToString();
    }
}
