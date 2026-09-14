using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    // HPを持っているプレイヤー
    [SerializeField] private PlayerHealth playerHealth_;

    // ハートのImage（左からHP1個分ずつ並べる）
    [SerializeField] private Image[] hearts_;

    // Update is called once per frame
    void Update()
    {
        int hp = playerHealth_.GetHp();

        // 現在のHPより後ろのハートを消し、それ以外は表示する
        for (int i = 0; i < hearts_.Length; i++)
        {
            hearts_[i].enabled = i < hp;
        }
    }
}
