using UnityEngine;

public class EnemyDeathAnimation : MonoBehaviour
{
    // 吹っ飛び時の重力
    [SerializeField] private float gravityScale_ = 2.0f;

    // 吹っ飛び時に加える力
    [SerializeField] private Vector2 flyOffForce_ = new Vector2(10.0f, 10.0f);

    // 吹っ飛び時の回転
    [SerializeField] private float flyOffTorque_ = -5.0f;

    // 完全に死ぬまでのタイマー
    [SerializeField] private float destroyTimer_ = 2.0f;

    // アニメーションが再生中か
    private bool isPlayingAnimation = false;

    // エネミーのリジットボディ
    private Rigidbody2D rigitBody2D_;

    // エネミーのコライダー
    private BoxCollider2D boxCollider2D_;

    // エネミーの体力
    private EnemyHealth enemyHealth_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // リジットボディ取得
        rigitBody2D_ = GetComponent<Rigidbody2D>();

        // コライダー取得
        boxCollider2D_ = GetComponent<BoxCollider2D>();

        // エネミーの体力
        enemyHealth_ = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションが再生中でないならここで処理を終了する。
        if (!isPlayingAnimation) return;

        // 1秒で0.1倍までスケールする
        transform.localScale *= (1.0f - 0.9f * Time.deltaTime);

        // 死ぬまでの時間を減算する
        destroyTimer_ -= Time.deltaTime;

        // サイズが0以下になったら死亡処理
        if (destroyTimer_ <= 0.0f)
        {
            // 削除
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// アニメーション開始
    /// </summary>
    public void StartAnimation()
    {
        // アニメーションが再生中
        isPlayingAnimation = true;

        // 当たり判定を無効化
        boxCollider2D_.enabled = false;

        // 重力適応
        rigitBody2D_.gravityScale = gravityScale_;

        // Freezeを全解除
        rigitBody2D_.constraints = RigidbodyConstraints2D.None;

        // 力を加える
        rigitBody2D_.AddForce(flyOffForce_, ForceMode2D.Impulse);

        // 回転を加える
        rigitBody2D_.AddTorque(flyOffTorque_, ForceMode2D.Impulse);
    }
}
