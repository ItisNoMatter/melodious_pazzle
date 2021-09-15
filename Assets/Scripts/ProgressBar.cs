using System.Collections;
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

    // 1ステージの時間を50sで固定
    // ここを60s以上にするとエラーが発生する。tickslist[n+1] - tickslist[n] の部分が、最後のほうまで行った時の配列オーバーによって起こる模様。
    private float maxTime = 50f;

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
