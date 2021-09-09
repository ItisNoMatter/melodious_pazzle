using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ProgressBar : MonoBehaviour
{
    ScoreManager scoreManager;
    public float currentTime;
    
    // 1ステージの時間を1m30sで固定
    private float maxTime = 90f;

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
        // このとき、ScoreManagerのscoreパラメータをResultに渡したい
        // https://qiita.com/tkyaji/items/361bd3d3d296516658f5
        if (slider.value == 1) {
            SceneManager.LoadScene("Scenes/Result");
        }
    }

}
