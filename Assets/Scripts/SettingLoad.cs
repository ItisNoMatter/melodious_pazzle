using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingLoad : MonoBehaviour
{
    [SerializeField] Image mainMenu;
    [SerializeField] Image configMenu;
    [SerializeField] Image loadMenu;

    // 決定音
    private AudioSource se;

    private void Start()
    {
        mainMenu.gameObject.SetActive(true);
        configMenu.gameObject.SetActive(false);
        se = GetComponent<AudioSource>();
        // se.PlayOneShot(se.clip);
    }
    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        configMenu.gameObject.SetActive(false);
    }

    public void OpenConfigMenu()
    {
        mainMenu.gameObject.SetActive(false);
        configMenu.gameObject.SetActive(true);
    }

    public void OpenLoadMenu()
    {

    }
}
