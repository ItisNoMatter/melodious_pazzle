using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Threading;
using System.Threading.Tasks;


public class SettingLoad : MonoBehaviour
{
    [SerializeField] Image mainMenu;
    [SerializeField] Image configMenu;
    [SerializeField] Image loadMenu;

    public Text Text;

    JsonSerialiZation jsonSeriali;
    // 決定音
    public AudioSource se;

    private void Start()
    {

        mainMenu.gameObject.SetActive(true);
        configMenu.gameObject.SetActive(false);
        se = GetComponent<AudioSource>();
        // se.PlayOneShot(se.clip);
    }
    public void OnPressedMainMenu()
    {
        _ = OpenMainMenu();
    }

    public void OnPressedConfigMenu()
    {
        _ = OpenConfigMenu();
    }

    public void OnPressedLoadMenu()
    {
        _ = OpenLoadMenu();
    }
    // メインメニュー遷移後の処理
    public async Task OpenMainMenu()
    {
        Text text = Text.GetComponent<Text>();
        // text.color = Color.yellow;

        // SE03(設定画面から出るときの音)を鳴らす
        se.PlayOneShot(se.clip);

        await Task.Delay(1000);

        mainMenu.gameObject.SetActive(true);
        configMenu.gameObject.SetActive(false);
    }

    // 設定画面遷移後の処理
    public async Task OpenConfigMenu()
    {
        Text text = Text.GetComponent<Text>();
        // text.color = Color.yellow;

        // SE05(設定画面に入る時の音)を鳴らす
        se.PlayOneShot(se.clip);

        await Task.Delay(1000);

        mainMenu.gameObject.SetActive(false);
        configMenu.gameObject.SetActive(true);
    }

    // ロード画面遷移後の処理
    public async Task OpenLoadMenu()
    {
        Text text = Text.GetComponent<Text>();
        // text.color = Color.yellow;

        // セーブデータをロード
        jsonSeriali.OnLoad();

        await Task.Delay(1000);

        // ゲームスタートの処理

    }
}
