using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text ScoreText;
    public Text NextText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = ScoreManager.getscore();

        ScoreText.text = string.Format("Score:{0}", score);
    }

    public void LoadPressedNextButton()
    {

        StartCoroutine(OnPressedNextButton());

    }

    public IEnumerator OnPressedNextButton()
    {

        Text nextText = NextText.GetComponent<Text>();
        nextText.color = Color.yellow;

        // 決定音
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Scenes/MainScene");

        yield return new WaitForSeconds(1.0f);

    }

    }
