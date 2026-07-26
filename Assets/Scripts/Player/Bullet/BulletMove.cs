using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // 速さ
    [SerializeField] private float speed_ = 7.5f;

    // 速度
    private Vector2 velocity_ = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 速度を設定する（右向きにspeed_分の速度）
        velocity_.x = speed_;
    }

    // Update is called once per frame
    void Update()
    {
        // 魔法弾に速度分の平行移動を加える。
        transform.Translate(velocity_ * Time.deltaTime);    
    }
}
