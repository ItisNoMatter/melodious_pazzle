﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// TODO: develop統合後、クラス名をProgressManagerにリファクタしたい
public class ProgressBar : MonoBehaviour
{
    ScoreManager scoreManager;
    public float currentTime;

    // ステージクリアを判定するための変数
    private static int stageClearJudge = 0;

    // 1ステージの時間を1m30sで固定
    // private float maxTime = 90f;

    // デバッグ用
    private float maxTime = 0.5f;

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

        // 進行率100%のときリザルト画面に遷移
        if (slider.value == 1) {
            SceneManager.LoadScene("Scenes/Result");
            stageClearJudge = 1;
        }

    }
    public static int getstageClearJudge()
    {
        return stageClearJudge;
    }

}
