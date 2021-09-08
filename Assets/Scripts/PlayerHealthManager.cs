using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    int maxHp = 300;
    int currentHp;
    public Slider slider;

    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
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
            int care = Random.Range(1, 10);

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
            currentHp = maxHp;
            SceneManager.LoadScene("Scenes/Title");
        }
    }
}