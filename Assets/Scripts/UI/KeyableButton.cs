using UnityEngine;
using UnityEngine.UI;

// クリックだけでなく、指定したキーでも同じボタンを押せるようにする
[RequireComponent(typeof(Button))]
public class KeyableButton : MonoBehaviour
{
    // ボタンのクリックと同時に反応させたいキー
    [SerializeField] private KeyCode key_ = KeyCode.Space;

    // 対象のボタン
    private Button button_;

    void Start()
    {
        button_ = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // キーが押されたら、ボタンをクリックしたときと同じ処理を呼び出す
        if (Input.GetKeyDown(key_))
        {
            button_.onClick.Invoke();
        }
    }
}
