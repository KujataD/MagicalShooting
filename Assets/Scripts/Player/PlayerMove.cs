using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // 移動速
    [SerializeField]private float speed_ = 5.0f;

    // プレイヤーHP
    private PlayerHealth playerHealth_;

    // 移動速度
    private Vector2 velocity_ = Vector2.zero;

    // 移動方向
    private Vector2 direction_ = Vector2.zero;

    // 当たり判定
    private BoxCollider2D col_;

    // カメラ
    private Camera camera_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 自身のゲームオブジェクト
        col_ = GetComponent<BoxCollider2D>();

        // カメラ取得
        camera_ = Camera.main;

        // プレイヤーのHP管理クラスを取得
        playerHealth_ = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // 方向をリセット
        direction_ = Vector2.zero;

        // 上矢印キーで Y 方向をプラス
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction_.y += 1.0f;
        }

        // 下矢印キーで Y 方向をマイナス
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction_.y -= 1.0f;
        }

        // 右矢印キーで X 方向をプラス
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction_.x += 1.0f;
        }

        // 左矢印キーで X 方向をマイナス
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction_.x -= 1.0f;
        }

        // 方向 x 速さ = 速度
        velocity_ = direction_.normalized * speed_ * Time.deltaTime;

        // プレイヤーに速度分の平行移動を加える。
        transform.Translate(velocity_);
    }

    // Updateより後の更新処理
    void LateUpdate()
    {
        // 死んでいた場合はリターン（ここで終了）
        if (!playerHealth_.IsAlive()) return;
        
        // screenサイズ取得
        float screenHalfHeight = camera_.orthographicSize;
        float screenHalfWidth = camera_.aspect * screenHalfHeight;

        // プレイヤーサイズ取得
        float halfWidth = col_.bounds.extents.x;
        float halfHeight = col_.bounds.extents.y;

        // 現時点の座標を取得
        Vector3 pos = transform.position;

        // カメラ座標
        Vector3 cameraPos = camera_.transform.position;

        // 画面内クランプ
        pos.x = Mathf.Clamp(pos.x, cameraPos.x - screenHalfWidth + halfWidth, cameraPos.x + screenHalfWidth - halfWidth);
        pos.y = Mathf.Clamp(pos.y, cameraPos.y - screenHalfHeight + halfHeight, cameraPos.y + screenHalfHeight - halfHeight);

        // 現在の座標に設定
        transform.position = pos;
    }

}
