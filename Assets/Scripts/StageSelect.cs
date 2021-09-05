using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void OnPressedStageButton(int stage)
    {
        if (stage == 1)
        {
            SceneManager.LoadScene("Scenes/Scene01");
        }

    }
}
