using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UIManager UIManager;

    // ----------------------- Scene Changing ------------------ \\
    public void LoadMenus()
    {
        SceneManager.LoadScene("Menus");
        UIManager.UpgradeState();
    }

    public void LoadGamePlay()
    {
        SceneManager.LoadScene("Gameplay");
        UIManager.GamePlayState();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
