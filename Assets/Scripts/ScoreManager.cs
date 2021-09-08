using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    int score = 0;
    int point;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            point = 50;

            score += point;

        }
    }
}
