using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int hp_ = 3;

    private EnemyDamageFlash flash_;
    private EnemyDeathAnimation deathAnimation_;
    void Start()
    {
        flash_ = GetComponent<EnemyDamageFlash>();
        deathAnimation_ = GetComponent<EnemyDeathAnimation>();
    }

    public void Damage(int damage)
    {
        // ダメージ計算
        hp_ -= damage;

        // わかりやすいようにログを出す
        Debug.Log("Enemy HP : " + hp_);

        // 赤色にセット
        flash_.Flash();

        // hpがゼロ以下ならエネミーを削除
        if (hp_ <= 0)
        {
            // GameManagerに撃破数を報告
            GameManager.Instance.AddDefeatCount();

            deathAnimation_.StartAnimation();
        }
    }

    /// <summary>
    /// 生きているかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsAlive()
    {
        return (hp_ > 0);
    }
}