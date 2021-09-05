using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    int maxHp = 300;
    int currentHp;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            int damage = Random.Range(1, 20);

            currentHp = currentHp - damage;

            slider.value = (float)currentHp / (float)maxHp;

            slider.value = (float)currentHp / (float)maxHp;

        }
    }

}
