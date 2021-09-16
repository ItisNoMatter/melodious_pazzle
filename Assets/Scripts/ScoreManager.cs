using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // 得点管理をPlayerHealthManagerで行うようになったため、こちらは削除してよさそう。
    public static int score;
    int point;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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

    public static int getscore()
    {
        return score;
    }
}
