using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // プレイヤーの体力
    private PlayerHealth health_;

    void Start()
    {  
        health_ = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyHealth enemy))
        {
            // すべての敵はダメージ1固定にしておく
            health_.Damage(1);
        }
    }
}
