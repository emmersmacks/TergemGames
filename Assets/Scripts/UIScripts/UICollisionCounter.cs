using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollisionCounter : MonoBehaviour
{
    [SerializeField] Text CollisionCountText;
    [SerializeField] private ResetCounters resetScript;

    public int collisionCount;

    private void OnEnable()
    {
        resetScript.Reset += ResetCounters;
    }

    private void OnDisable()
    {
        resetScript.Reset += ResetCounters;
    }

    private void ResetCounters()
    {
        collisionCount = 0;
    }

    private void Update()
    {
        if(collisionCount % 2 == 0)
        {
            CollisionCountText.text = collisionCount.ToString();
        }
    }
}
