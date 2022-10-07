using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // ----------------------- Scene Changing ------------------ \\
    public void LoadMenus()
    {
        SceneManager.LoadScene("Menus");
    }

    public void LoadGamePlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
