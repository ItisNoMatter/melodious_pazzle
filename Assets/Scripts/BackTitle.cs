using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{
    public Text ExitText;
    public void OnPressedExitButton()
    {
        _ = OpenMainMenu();
    }
    // メインメニュー遷移後の処理
    public async Task OpenMainMenu()
    {

        Text exitText = ExitText.GetComponent<Text>();
        exitText.color = Color.yellow;

        // SE03(設定画面から出るときの音)を鳴らす
        GetComponent<AudioSource>().Play();

        await Task.Delay(500);

        SceneManager.LoadScene("Scenes/Title");

    }
}
