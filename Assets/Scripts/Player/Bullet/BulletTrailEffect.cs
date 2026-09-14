using UnityEngine;

public class BulletTrailEffect : MonoBehaviour
{
    // 飛んでいる間に後ろへ流すきらめきエフェクト
    [SerializeField] private GameObject trailEffectPrefab_;

    // 元のエフェクトは規模が小さいため、見やすいように拡大する倍率
    [SerializeField] private float effectScale_ = 4.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (trailEffectPrefab_ != null)
        {
            // 弾の子として生成し、常についてくるようにする
            GameObject effect = Instantiate(trailEffectPrefab_, transform.position, Quaternion.identity, transform);
            effect.transform.localScale *= effectScale_;
        }
    }
}
