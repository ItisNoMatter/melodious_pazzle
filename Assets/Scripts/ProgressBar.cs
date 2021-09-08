using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    private float currentTime;
    
    // 1ステージの時間を1m30sで固定
    private float maxTime = 90f;

    public float timeParameter;

    public Slider slider;
    void Start()
    {
        slider.value = 0;
        currentTime = 0;
        slider.gameObject.SetActive(true);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        slider.value = (float)currentTime / (float)maxTime;
        // Debug.Log(currentTime);
        progressParameter(currentTime);
    }

    public void progressParameter(float currentTime)
    {
        timeParameter = currentTime;
    }

}
