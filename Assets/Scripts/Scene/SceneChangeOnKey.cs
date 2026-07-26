using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnKey : MonoBehaviour
{
    // 押されたら遷移するキー
    [SerializeField] private KeyCode key_ = KeyCode.Space;

    // 遷移先のシーン名
    [SerializeField] private string nextSceneName_ = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // nullチェック
        Debug.Assert(nextSceneName_ != "", "nextSceneName_ が設定されていません！");
    }

    // Update is called once per frame
    void Update()
    {
        // キーが押された瞬間にシーンを切り替える
        if (Input.GetKeyDown(key_))
        {
            SceneManager.LoadScene(nextSceneName_);
        }
    }
}
