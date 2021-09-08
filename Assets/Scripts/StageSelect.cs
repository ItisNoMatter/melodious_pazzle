using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public GameObject StageText;

    public void LoadPressedButton(int stage)
    {
        Text stageText = StageText.GetComponent<Text>();
        stageText.color = Color.yellow;
        StartCoroutine(OnPressedStageButton(1));
        // Debug.Log(stage);
    }

    public IEnumerator OnPressedStageButton(int stage)
    {

        if (stage == 1)
        {
            SceneManager.LoadScene("Scenes/MainScene");
        }

        else if (stage == 2)
        {
            // 未実装
            // ヒープ音など鳴らせるとよい？
        }

        // 1秒待つ
        yield return new WaitForSeconds(1.0f);
    }
}
