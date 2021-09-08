using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    ProgressBar progress;
    float timeParameter;
    int score = 0;
    int point;
    // Start is called before the first frame update
    void Start()
    {
        timeParameter = progress.timeParameter;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            point = 50;

            score += point;

        }

        if (timeParameter == 90f)
        {
            SceneManager.LoadScene("Scenes/Result");
        }
    }
}
