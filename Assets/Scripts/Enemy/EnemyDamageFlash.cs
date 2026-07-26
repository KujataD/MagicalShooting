using UnityEngine;

public class EnemyDamageFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer_;

    void Start()
    {
        spriteRenderer_ = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // 白色にセット
        spriteRenderer_.color = Color.white;
    }

    public void Flash()
    {
        // 赤色にセット
        spriteRenderer_.color = Color.red;
    }
}