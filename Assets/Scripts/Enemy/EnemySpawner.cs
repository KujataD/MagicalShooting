using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 敵のプレハブ
    [SerializeField] private GameObject enemyPrefab_;

    // スポーン間隔（秒）
    [SerializeField] private float spawnDuration_ = 1.0f;

    // スポーンエリア
    private BoxCollider2D spawnArea_;

    // スポーン用タイムカウンター
    private float timeCounter_ = 0.0f;

    void Start()
    {
        // nullチェック
        Debug.Assert(enemyPrefab_ != null, "enemyPrefab_ が設定されていません！");
        
        // スポーンエリア設定
        spawnArea_ = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // 時間を加算
        timeCounter_ += Time.deltaTime;

        if (timeCounter_ >= spawnDuration_)
        {
            // スポーンエリアの半分の高さを取得
            float spawnAreaHalfHight = spawnArea_.bounds.extents.y;

            // Y座標の値をAreaの範囲でランダムにする
            float spawnRamdomY = Random.Range(transform.position.y - spawnAreaHalfHight, transform.position.y + spawnAreaHalfHight);

            // スポーンさせる座標
            Vector3 spawnPos = new Vector3(transform.position.x, spawnRamdomY, transform.position.z);

            // エネミー生成
            Instantiate(enemyPrefab_, spawnPos, Quaternion.identity);

            // タイムカウンターリセット
            timeCounter_ = 0.0f;
        }
    }

}
