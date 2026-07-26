using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    // エネミーの体力
   private EnemyHealth health_;

    void Start()
    {
        health_ = GetComponent<EnemyHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たったものの中にBulletParamがあれば、ダメージを食らう。
        if (collision.collider.TryGetComponent(out BulletParam magic))
        {
            health_.Damage(magic.damage_);
        }
    }
}