using System.Collections;
using System.Collections.Generic;
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
    int highScore;
    int rank;
    int[] loadSaveData = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        Text rankText = RankText.GetComponent<Text>();
        Text scoreText = ScoreText.GetComponent<Text>();
        Text highScoreText = HighScoreText.GetComponent<Text>();

        score = ScoreManager.getscore();

        loadSaveData = JsonSerialiZation.loaddata;
        Debug.Log("LoadScore" + loadSaveData[0]);
        Debug.Log("LoadHighScore" + loadSaveData[1]);

        if (score >= 90)
        {
            rankText.text = string.Format("Rank:S");
        }
        else if (score >= 80)
        {
            rankText.text = string.Format("Rank:A");
        }
        else if (score >= 70)
        {
            rankText.text = string.Format("Rank:B");
        }

        // ハイスコア更新
        if (score >= highScore)
        {
            highScore = score;
        }

        // スコア更新時、ハイスコアの表示も更新
        if (score >= loadSaveData[1])
        {
            loadSaveData[1] = score;
        }

        rankText.text = string.Format("Rank:C");

        highScoreText.text = string.Format("HighScore:{0}", loadSaveData[1]);

        scoreText.text = string.Format("Score:{0}", score);

        // Twitter共有
        // ramencadenceの部分は任意の(UnityRoom投稿時に設定した)"YOUR-GAMEID"
        naichilab.UnityRoomTweet.Tweet("ramencadence", "RamenCadenceでハイスコア" + loadSaveData[1] + "を取得しました！");
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
