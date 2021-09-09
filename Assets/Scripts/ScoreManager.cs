using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    int score;
    int point;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private int OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            point = 50;

            score += point;

            return score;

        }
        return score;

    }
}
