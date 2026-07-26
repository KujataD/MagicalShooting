using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // シングルトン化
    public static GameManager Instance { get; private set; }

    // ゲームの状態
    public enum GameState
    {
        PLAYING,
        GAMEOVER,
        GAMECLEAR,
    }

    // ゲームの状態
    public GameState gameState_ { get; private set; }

    // プレイヤーの体力
    [SerializeField] private PlayerHealth playerHealth_;

    // プレイヤーのやられアニメーション
    [SerializeField] private PlayerDeathAnimation playerDeathAnimation_;

    // クリアに必要な撃破数
    [SerializeField] private int clearTargetCount_ = 20;

    // クリアしてからシーン切り替えまでの待機時間（秒）
    [SerializeField] private float clearWaitTime_ = 1.5f;

    // 敵の撃破数
    private int defeatCount_ = 0;

    void Awake()
    {
        // instance元を設定
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // nullチェック
        Debug.Assert(playerHealth_ != null, "PlayerHealth が設定されていません");
        Debug.Assert(playerDeathAnimation_ != null, "PlayerDeathAnimation が設定されていません");

        // 開始時のゲーム状態を設定
        gameState_ = GameState.PLAYING;
    }

    // Update is called once per frame
    void Update()
    {
        // 各状態の更新
        switch (gameState_)
        {
            case GameState.PLAYING:
                // プレイヤーが死んだらゲームオーバー
                if (!playerHealth_.IsAlive())
                {
                    gameState_ = GameState.GAMEOVER;
                }

                // 敵を規定数倒したらゲームクリア
                if (defeatCount_ >= clearTargetCount_)
                {
                    gameState_ = GameState.GAMECLEAR;
                }

                break;
            case GameState.GAMEOVER:
                // ゲームオーバーシーンに切り替え
                if (playerDeathAnimation_.isAnimationFinished_)
                {
                    ChangeGameOverScene();
                }
                break;

            case GameState.GAMECLEAR:
                // 少し待ってからゲームクリアシーンに切り替え
                clearWaitTime_ -= Time.deltaTime;
                if (clearWaitTime_ <= 0.0f)
                {
                    ChangeGameClearScene();
                }
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// シーン切り替え
    /// </summary>
    void ChangeGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    /// <summary>
    /// シーン切り替え（ゲームクリア）
    /// </summary>
    void ChangeGameClearScene()
    {
        SceneManager.LoadScene("GameClearScene");
    }

    /// <summary>
    /// 敵の撃破数を加算
    /// </summary>
    public void AddDefeatCount()
    {
        // 撃破数を加算
        defeatCount_++;

        // わかりやすいようにログを出す
        Debug.Log("Defeat Count : " + defeatCount_);
    }

}
