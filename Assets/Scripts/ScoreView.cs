using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text RankText;
    public Text ScoreText;
    public Text ExitText;
    public Text RetryText;
    public Text HighScoreText;

    int score;
    public static int highScore;
    int rank;
    int[] loadSaveData = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        Text rankText = RankText.GetComponent<Text>();
        Text scoreText = ScoreText.GetComponent<Text>();
        Text highScoreText = HighScoreText.GetComponent<Text>();

        //スコアの取得をしたい
        score = PlayerHealthManager.score;
        highScore = loadSaveData[1];

        loadSaveData = JsonSerialiZation.loaddata;
        Debug.Log("LoadScore" + loadSaveData[0]);
        Debug.Log("LoadHighScore" + loadSaveData[1]);

        if (score >= 900)
        {
            rankText.text = string.Format("Rank:S");
        }
        else if (score >= 700)
        {
            rankText.text = string.Format("Rank:A");
        }
        else if (score >= 50)
        {
            rankText.text = string.Format("Rank:B");
        }
        else
        {
            rankText.text = string.Format("Rank:C");
        }

        // ハイスコア更新
        if (score >= highScore)
        {
            highScore = score;
        }

        // スコア更新時、ハイスコアの表示も更新
        if (score >= highScore)
        {
            highScore = score;
        }

        //rankText.text = string.Format("Rank:C");

        highScoreText.text = string.Format("HighScore:{0}", highScore);

        scoreText.text = string.Format("Score:{0}", score);

//        if (EditorUtility.DisplayDialog("Result", "結果をTwitterで共有しよう！", "Twitterを開く", "閉じる"))
//        {
            naichilab.UnityRoomTweet.Tweet("ramencadence", "RamenCadenceでハイスコア" + highScore + "を取得しました！");
//        }
//        else
        {
            //Debug.Log("No");
        }
        // Twitter共有
        // ramencadenceの部分は任意の(UnityRoom投稿時に設定した)"YOUR-GAMEID"
        //naichilab.UnityRoomTweet.Tweet("ramencadence", "RamenCadenceでハイスコア" + loadSaveData[1] + "を取得しました！");
        // Android/iOS用
        // SocialConnector.SocialConnector.Share("RamenCadenceでハイスコア" + loadSaveData[1] + "を取得しました！", "https://twitter.com/**********", null);

    }

    public void LoadPressedExitButton()
    {

        StartCoroutine(OnPressedExitButton());

    }

    public void LoadPressedRetryButton()
    {

        StartCoroutine(OnPressedRetryButton());

    }

    public IEnumerator OnPressedExitButton()
    {

        Text exitText = ExitText.GetComponent<Text>();
        exitText.color = Color.yellow;

        // 決定音
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Scenes/Title");

        yield return new WaitForSeconds(1.0f);

    }

    public IEnumerator OnPressedRetryButton()
    {

        Text retryText = RetryText.GetComponent<Text>();
        retryText.color = Color.yellow;

        // 決定音
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Scenes/MainScene");

        yield return new WaitForSeconds(1.0f);

    }

}
