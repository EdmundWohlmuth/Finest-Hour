using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UIManager UIManager;
    public GameManager gameManager;

    // ----------------------- Scene Changing ------------------ \\
    public void LoadMenus()
    {
        SceneManager.LoadScene("Menus");
        UIManager.UpgradeState();
        gameManager.SaveGame();
    }

    public void NewGame()
    {
        if (gameManager.DoesFileExist() == true)
        {
            UIManager.NewGameState();
        }
        else if (gameManager.DoesFileExist() == false)
        {
            SceneManager.LoadScene("Gameplay");
            UIManager.GamePlayState();
        }
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

    public void SaveAndQuit()
    {
        gameManager.SaveGame();
        Application.Quit();
    }
}
