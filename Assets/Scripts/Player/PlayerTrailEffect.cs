using UnityEngine;

public class PlayerTrailEffect : MonoBehaviour
{
    // 飛行中に後ろへ流す軌跡エフェクト
    [SerializeField] private GameObject trailEffectPrefab_;

    // 元のエフェクトは規模が小さいため、見やすいように拡大する倍率
    [SerializeField] private float effectScale_ = 4.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (trailEffectPrefab_ != null)
        {
            // プレイヤーの子として生成し、常についてくるようにする
            GameObject effect = Instantiate(trailEffectPrefab_, transform.position, Quaternion.identity, transform);
            effect.transform.localScale *= effectScale_;
        }
    }
}
