using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingLoad : MonoBehaviour
{
    [SerializeField] Image mainMenu;
    [SerializeField] Image settingMenu;
    [SerializeField] Image loadMenu;
    public void OpenSettingMenu()
    {
        mainMenu.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(true);
    }

    public void OpenLoadMenu()
    {
        mainMenu.gameObject.SetActive(false);
        loadMenu.gameObject.SetActive(true);
    }
}
