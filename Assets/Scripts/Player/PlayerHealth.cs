using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int hp_ = 1;

    // プレイヤー死亡アニメーション
    private PlayerDeathAnimation playerDeathAnimation_;

    void Start()
    {
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

}