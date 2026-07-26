using UnityEngine;

public class EnemyDestroyOutsideScreen : MonoBehaviour
{
    // 魔法弾の当たり判定
    private BoxCollider2D col_;

    // カメラ
    private Camera camera_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 当たり判定取得
        col_ = GetComponent<BoxCollider2D>();
        
        // メインカメラ（現在画面を写しているカメラ）を取得
        camera_ = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // 画面の縦幅（半径）を取得
        float screenHalfHeight = camera_.orthographicSize;
        // 画面の横幅（半径）を取得
        float screenHalfWidth = screenHalfHeight * camera_.aspect;

        // 敵の横幅（半径）を取得
        float halfWidth = col_.bounds.extents.x;
        // カメラの座標を取得
        Vector3 cameraPos = camera_.transform.position;

        // 画面右端の座標 + 弾の半径分右にずらす（画面から完全に外に出たときに消したいので）
        float leftBoundary = cameraPos.x - screenHalfWidth - halfWidth;

        // 弾の座標が、画面右端よりも右側に達していた時、この弾を消す。
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}