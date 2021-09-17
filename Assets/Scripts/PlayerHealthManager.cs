using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    int maxHp = 100; // HP最大値は100固定
    int currentHp;
    public Slider slider;

    public static int score;

    public AudioSource se;

    [SerializeField]
    GameObject playerObject;

    [SerializeField]
    GameObject mainCamera;

    bool playerDead;

    void Start()
    {
        playerDead = false;
        score = 0;
        slider.value = 0.3f;
        currentHp = 30; // 初期HPは30固定
        slider.gameObject.SetActive(true);
        se = GetComponent<AudioSource>();

    }

    /*private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            int damage = Random.Range(1, 20);

            currentHp = currentHp - damage;

            slider.value = (float)currentHp / (float)maxHp;

            Debug.Log(currentHp);
            currentPlayerHp(currentHp);
        }
        currentPlayerHp(currentHp);
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            int damage = Random.Range(1, 20);

            currentHp = currentHp - damage;

            slider.value = (float)currentHp / (float)maxHp;

            //Debug.Log(currentHp);
            //currentPlayerHp(currentHp);
        }
        if (collider.gameObject.tag == "powerUpLv1")
        {
            int care = 1; // パワー回復アイテムは5,20,30の3つを想定

            currentHp = currentHp + care;

            slider.value = (float)currentHp / (float)maxHp;

            score += 5;

            //Debug.Log(currentHp);
            //currentPlayerHp(currentHp);
        }
        if (collider.gameObject.tag == "powerUpLv2")
        {
            int care = 2; // パワー回復アイテムは5,20,30の3つを想定

            currentHp = currentHp + care;

            slider.value = (float)currentHp / (float)maxHp;

            score += 20;

            //Debug.Log(currentHp);
            //currentPlayerHp(currentHp);
        }
        if (collider.gameObject.tag == "powerUpLv3")
        {
            int care = 3; // パワー回復アイテムは5,20,30の3つを想定

            currentHp = currentHp + care;

            slider.value = (float)currentHp / (float)maxHp;

            score += 30;

            //Debug.Log(currentHp);
            //currentPlayerHp(currentHp);
        }
        currentPlayerHp(currentHp);
    }

    private void currentPlayerHp(int currentHp)
    {
        //Debug.Log(currentHp);

        if (currentHp <= 0)
        {
            if (playerDead == false)
            {
                //Debug.Log("Game Over");
                slider.gameObject.SetActive(false);

                playerDead = true;
                Debug.Log(se);

                Invoke("ShakeCamera", 1.0f);
                Invoke("PlayerDirection", 1.5f);
                Invoke("PlayerMove", 2.0f);

                se.PlayOneShot(se.clip);

                Invoke("SceneMove", 3.0f);

            }
        }
    }

    private void ShakeCamera()
    {
        iTween.ShakePosition(mainCamera, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 1.0f));
    }

    private void PlayerDirection()
    {
        iTween.RotateBy(playerObject, iTween.Hash("x", 180f));
    }

    private void PlayerMove()
    {
        iTween.MoveAdd(playerObject, iTween.Hash("y", -100f));
    }

    private void SceneMove()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }

    public void Update()
    {
        
    }
}
