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

    JsonSerialiZation jsonSeriali;
    // 決定音
    private AudioSource se;

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
        // SE03(設定画面から出るときの音)を鳴らす
        se.PlayOneShot(se.clip);

        await Task.Delay(3);

        mainMenu.gameObject.SetActive(true);
        configMenu.gameObject.SetActive(false);
    }

    // 設定画面遷移後の処理
    public async Task OpenConfigMenu()
    {
        // SE05(設定画面に入る時の音)を鳴らす
        se.PlayOneShot(se.clip);

        await Task.Delay(3);

        mainMenu.gameObject.SetActive(false);
        configMenu.gameObject.SetActive(true);
    }

    // ロード画面遷移後の処理
    public async Task OpenLoadMenu()
    {
        // セーブデータをロード
        jsonSeriali.OnLoad();

        await Task.Delay(3);

        // ゲームスタートの処理

    }
}
