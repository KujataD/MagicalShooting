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

    // 最大チャージにかかる秒数
    [SerializeField] private float chargeTimeToMax_ = 1.0f;

    // 最大までチャージしたときのダメージ倍率
    [SerializeField] private float maxChargeDamageMultiplier_ = 3.0f;

    // 最大までチャージしたときの見た目の拡大率
    [SerializeField] private float maxChargeScaleMultiplier_ = 2.0f;

    // チャージ中かどうか
    private bool isCharging_ = false;

    // 現在のチャージ時間
    private float chargeTime_ = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押した瞬間にチャージを開始する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging_ = true;
            chargeTime_ = 0.0f;
        }

        // チャージ中はスペースキーを押している時間を数える(最大値まで)
        if (isCharging_ && Input.GetKey(KeyCode.Space))
        {
            chargeTime_ = Mathf.Min(chargeTime_ + Time.deltaTime, chargeTimeToMax_);
        }

        // スペースキーを離した瞬間に、チャージ量に応じた魔法弾を発射する
        if (isCharging_ && Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
            isCharging_ = false;
        }
    }

    /// <summary>
    /// チャージ量に応じた魔法弾を発射する
    /// </summary>
    private void Fire()
    {
        // チャージの度合い(0〜1)
        float chargeRatio = chargeTime_ / chargeTimeToMax_;

        // 生成する(弾のプレハブを, プレイヤーの座標で, 何も回転していない状態で)
        GameObject bullet = Instantiate(bulletPrefab_, transform.position, quaternion.identity);

        // チャージ量に応じてダメージを増やす
        if (bullet.TryGetComponent(out BulletParam param))
        {
            float damageMultiplier = Mathf.Lerp(1.0f, maxChargeDamageMultiplier_, chargeRatio);
            param.damage_ = Mathf.RoundToInt(param.damage_ * damageMultiplier);
        }

        // チャージ量に応じて見た目も大きくする
        float scaleMultiplier = Mathf.Lerp(1.0f, maxChargeScaleMultiplier_, chargeRatio);
        bullet.transform.localScale *= scaleMultiplier;

        // 発射音を鳴らす
        audioSource_.PlayOneShot(shootSe_);
    }
}
