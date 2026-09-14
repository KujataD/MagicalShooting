using UnityEngine;

public class GameClearEffect : MonoBehaviour
{
    // クリア時にお祝いとして出す魔法陣エフェクト
    [SerializeField] private GameObject clearEffectPrefab_;

    // 元のエフェクトは規模が小さいため、見やすいように拡大する倍率
    [SerializeField] private float effectScale_ = 4.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (clearEffectPrefab_ != null)
        {
            GameObject effect = Instantiate(clearEffectPrefab_, transform.position, Quaternion.identity);
            effect.transform.localScale *= effectScale_;
        }
    }
}
