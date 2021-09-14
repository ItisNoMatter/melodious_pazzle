using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonSerialiZation : MonoBehaviour
{
    /*
     * セーブデータとして保持しておきたいもの
     * ステージクリアログ
     * ハイスコア
     */

    public int score;
    public int highScore;
    // 保持しておきたいデータを格納するための配列
    public int[] savedata = new int[2];
    // クリア判定
    public int stageClearJudge;

    [System.Serializable]
    private struct saveData
    {
        public int[] clearData;
    }

    // ファイルパス
    private string _dataPath;
    saveData savedataObj;

    public AudioSource se;

    private void Start()
    {
        se = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        // ファイルパスはカレントディレクトリ直下を指定
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "savedata.json");
    }
    public void OnPressedSaveButton()
    {
        score = ScoreManager.getscore();
        highScore = 0;
        stageClearJudge = ProgressBar.getstageClearJudge();
        
        if (score >= highScore)
        {
            highScore = score;
        }

        savedata = new int[] { score, highScore, stageClearJudge, 0, 0 };

        Debug.Log(score);

        OnSave();

    }

    // JSON形式にシリアライズしてセーブ
    private void OnSave()
    {
        // シリアライズするオブジェクトを作成
        var obj = new saveData
        {
            clearData = savedata
        };

        // JSON形式にシリアライズ
        var json = JsonUtility.ToJson(obj, false);

        // JSONデータをファイルに保存
        File.WriteAllText(_dataPath, json);
    }

    public void OnLoad()
    {
        // 念のためファイルの存在チェック
        if (!File.Exists(_dataPath)) return;

        // JSONデータとしてデータを読み込む
        var json = File.ReadAllText(_dataPath);

        // JSON形式からオブジェクトにデシリアライズ
        var obj = JsonUtility.FromJson<saveData>(json);

        // savedata.jsonから読み込んだクリアデータの整合性確認用
        Debug.Log("score" + obj.clearData[0]);
        Debug.Log("highScore" + obj.clearData[1]);
        Debug.Log("stageClearJudge" + obj.clearData[2]);

        if (!File.Exists(_dataPath))
        {
            // セーブデータが存在しないとき
            se.PlayOneShot(se.clip);
            Debug.Log("セーブデータがありません");
        }
        else
        {
            // ゲームスタートの処理
            se.PlayOneShot(se.clip);
            SceneManager.LoadScene("Scenes/MainScene");
        }
    }

}