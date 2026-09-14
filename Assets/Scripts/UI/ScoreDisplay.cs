using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // 撃破数を表示するテキスト
    [SerializeField] private TextMeshProUGUI scoreText_;

    // Update is called once per frame
    void Update()
    {
        // 敵を倒すたびに加算されるスコアとして表示する
        int defeatCount = GameManager.Instance.GetDefeatCount();
        scoreText_.text = "SCORE " + defeatCount;
    }
}
