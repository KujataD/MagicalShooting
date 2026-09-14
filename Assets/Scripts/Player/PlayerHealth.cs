using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // 最大HP（ハート表示の数と一致させる）
    [SerializeField] private int maxHp_ = 3;

    // 現在のHP
    private int hp_;

    // プレイヤー死亡アニメーション
    private PlayerDeathAnimation playerDeathAnimation_;

    void Start()
    {
        // 開始時は満タンのHPにする
        hp_ = maxHp_;

        // プレイヤー死亡アニメーションを取得
        playerDeathAnimation_ = GetComponent<PlayerDeathAnimation>();
    }

    public void Damage(int damage)
    {
        // ダメージ計算
        hp_ -= damage;

        // わかりやすいようにログを出す
        Debug.Log("Player HP : " + hp_);

        // hpがゼロ以下ならプレイヤーを削除
        if (hp_ <= 0)
        {
            playerDeathAnimation_.StartAnimation();
        }
    }

    public bool IsAlive() { return hp_ > 0; }

    /// <summary>
    /// 現在のHPを取得（ハート表示用）
    /// </summary>
    public int GetHp()
    {
        return hp_;
    }

    /// <summary>
    /// 最大HPを取得（ハート表示用）
    /// </summary>
    public int GetMaxHp()
    {
        return maxHp_;
    }

}