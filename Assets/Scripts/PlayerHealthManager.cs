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

    [SerializeField]
    GameObject playerObject;

    [SerializeField]
    GameObject mainCamera;

    void Start()
    {
        slider.value = 1;
        currentHp = 30; // 初期HPは30固定
        slider.gameObject.SetActive(true);
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
            currentPlayerHp(currentHp);
        }
        if (collider.gameObject.tag == "powerUpLv1")
        {
            int care = 5; // パワー回復アイテムは5,20,30の3つを想定

            currentHp = currentHp + care;

            slider.value = (float)currentHp / (float)maxHp;

            //Debug.Log(currentHp);
            currentPlayerHp(currentHp);
        }
        if (collider.gameObject.tag == "powerUpLv2")
        {
            int care = 10; // パワー回復アイテムは5,20,30の3つを想定

            currentHp = currentHp + care;

            slider.value = (float)currentHp / (float)maxHp;

            //Debug.Log(currentHp);
            currentPlayerHp(currentHp);
        }
        if (collider.gameObject.tag == "powerUpLv3")
        {
            int care = 30; // パワー回復アイテムは5,20,30の3つを想定

            currentHp = currentHp + care;

            slider.value = (float)currentHp / (float)maxHp;

            //Debug.Log(currentHp);
            currentPlayerHp(currentHp);
        }
        currentPlayerHp(currentHp);
    }

    private void currentPlayerHp(int currentHp)
    {
        //Debug.Log(currentHp);

        if (currentHp <= 0)
        {
            Debug.Log("Game Over");
            slider.gameObject.SetActive(false);

            Invoke("ShakeCamera", 1.0f);
            Invoke("PlayerDirection", 1.5f);
            Invoke("PlayerMove", 2.0f);
            Invoke("SceneMove", 3.0f);
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

}