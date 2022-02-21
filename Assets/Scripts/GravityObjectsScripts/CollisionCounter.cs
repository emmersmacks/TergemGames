
using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    [SerializeField] UICollisionCounter CollisionText;
    private void OnCollisionEnter(Collision collision)
    {
        CollisionText.CollisionCount++;
    }
}
