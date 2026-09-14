using Unity.Mathematics;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 魔法弾のプレハブ
    [SerializeField] private GameObject bulletPrefab_;

    // 発射音を鳴らすAudioSource
    [SerializeField] private AudioSource audioSource_;

    // 発射音
    [SerializeField] private AudioClip shootSe_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーで魔法弾発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 生成する(弾のプレハブを, プレイヤーの座標で, 何も回転していない状態で)
            Instantiate(bulletPrefab_, transform.position, quaternion.identity);

            // 発射音を鳴らす
            audioSource_.PlayOneShot(shootSe_);
        }
    }
}