using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // 命中したときに出すエフェクト
    [SerializeField] private GameObject hitEffectPrefab_;

    // エフェクトを消すまでの時間（秒）
    [SerializeField] private float hitEffectLifeTime_ = 1.0f;

    // 元のエフェクトは規模が小さいため、見やすいように拡大する倍率
    [SerializeField] private float hitEffectScale_ = 4.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out EnemyHealth enemy))
        {
            // 命中エフェクトを出す
            if (hitEffectPrefab_ != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab_, transform.position, Quaternion.identity);
                effect.transform.localScale *= hitEffectScale_;

                // ループ再生のエフェクトなので、放っておくと消えないため一定時間で破棄する
                Destroy(effect, hitEffectLifeTime_);
            }

            Destroy(gameObject);
        }
    }
}
