using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollisionCounter : MonoBehaviour
{
    [SerializeField] private Text _collisionCountText;
    [SerializeField] private CounterResetter _resetScript;

    private int _collisionCount;
    public int CollisionCount
    {
        get
        {
            return _collisionCount;
        }
        set
        {
            if (_collisionCount != value)
            {
                _collisionCount = value;
                UpdateText();
            }
        }
    }

    private void OnEnable()
    {
        _resetScript.Reset += ResetCounters;
    }

    private void OnDisable()
    {
        _resetScript.Reset += ResetCounters;
    }

    private void ResetCounters()
    {
        CollisionCount = 0;
    }

    private void UpdateText()
    {
        if(CollisionCount % 2 == 0)
        {
            _collisionCountText.text = "Столкновений: " + (CollisionCount / 2).ToString();
        }
    }
}
