using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]private float speed_ = 8.0f;

    private Vector2 velocity_ = Vector2.zero;

    // エネミーの体力を
    private EnemyHealth enemyHealth_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity_.x = -speed_;
        enemyHealth_ = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // 死んでいたらリターン（ここで終了）
        if(!enemyHealth_.IsAlive()) return;

        // 座標更新
        transform.position += (Vector3)(velocity_ * Time.deltaTime);
    }
}