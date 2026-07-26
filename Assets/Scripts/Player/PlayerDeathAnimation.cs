using System.Collections;
using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    // アニメーション待機時間
    [SerializeField] private float animationWaitForSeconds_ = 0.5f;

    // 吹っ飛び時の重力
    [SerializeField] private float gravityScale_ = 2.0f;

    // 吹っ飛び時に加える力
    [SerializeField] private Vector2 flyOffForce_ = new Vector2(0.0f, 15.0f);

    // 吹っ飛び時の回転
    [SerializeField] private float flyOffTorque_ = -5.0f;

    // アニメーションが再生中か
    private bool isPlayingAnimation_ = false;

    // アニメーションが完了したか
    public bool isAnimationFinished_ { get; private set; } = false;

    // エネミーのリジットボディ
    private Rigidbody2D rigitBody2D_;

    // エネミーのコライダー
    private BoxCollider2D boxCollider2D_;

    // カメラ
    private Camera camera_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // リジットボディ取得
        rigitBody2D_ = GetComponent<Rigidbody2D>();

        // コライダー取得
        boxCollider2D_ = GetComponent<BoxCollider2D>();

        // カメラ取得
        camera_ = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションが再生中でないならここで処理を終了する。
        if (!isPlayingAnimation_) return;

        // screenサイズ取得
        float screenHalfHeight = camera_.orthographicSize;

        // プレイヤーサイズ取得
        float halfHeight = boxCollider2D_.bounds.extents.y;

        // 画面外に出たらアニメーション完了
        if (transform.position.y < camera_.transform.position.y - screenHalfHeight - halfHeight)
        {
            isAnimationFinished_ = true;
        }

    }

    /// <summary>
    /// アニメーション開始
    /// </summary>
    public void StartAnimation()
    {
        StartCoroutine(AnimationCoroutine());
    }

    /// <summary>
    /// 死亡アニメーション
    /// </summary>
    private IEnumerator AnimationCoroutine()
    {
        // アニメーション待機
        yield return new WaitForSeconds(animationWaitForSeconds_);

        // アニメーション再生開始
        isPlayingAnimation_ = true;

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
