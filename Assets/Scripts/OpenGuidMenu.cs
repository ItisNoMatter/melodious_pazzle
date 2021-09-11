using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGuidMenu : MonoBehaviour
{
    bool onPressedXkey = false;
    int score;

    private void Start()
    {
        score = ScoreManager.getscore();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            // Xキー未入力
            if (!onPressedXkey)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("X");
                    SceneManager.LoadScene("Scenes/Guid");
                    onPressedXkey = true;
                }
            }
            else
            {
                SceneManager.LoadScene("Scenes/Title");
                onPressedXkey = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "Guid")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("X");
                SceneManager.LoadScene("Scenes/Title");
                onPressedXkey = false;
            }
        }

        /*
         * パラメータ未処理のままメインシーンでガイドに遷移すると、復帰時にスコアと経過時間がリセットされてしまうため
         * メインシーンからの遷移は未対応としています
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ゲームを中断します");
            SceneManager.LoadScene("Scenes/Title");
        }
    }
}
