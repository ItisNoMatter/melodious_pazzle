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

    int score;
    int rank;

    // Start is called before the first frame update
    void Start()
    {
        Text rankText = RankText.GetComponent<Text>();
        Text scoreText = ScoreText.GetComponent<Text>();

        score = ScoreManager.getscore();

        if (rank >= 90)
        {
            rankText.text = string.Format("Rank:S");
        }
        else if (rank >= 80)
        {
            rankText.text = string.Format("Rank:A");
        }
        else if (rank >= 70)
        {
            rankText.text = string.Format("Rank:B");
        }

        rankText.text = string.Format("Rank:C");

        scoreText.text = string.Format("Score:{0}", score);

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
