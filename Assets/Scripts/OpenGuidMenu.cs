using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGuidMenu : MonoBehaviour
{
    bool onPressedXkey = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X");
            SceneManager.LoadScene("Scenes/Guid");
            onPressedXkey = true;
        }
        if (onPressedXkey==false)
        {
            SceneManager.LoadScene("Scenes/Title");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ゲームを中断します");
            SceneManager.LoadScene("Scenes/Title");
        }
    }
}
