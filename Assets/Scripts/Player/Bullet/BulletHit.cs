using UnityEngine;

public class BulletHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out EnemyHealth enemy))
        {
            Destroy(gameObject);
        }
    }
}
