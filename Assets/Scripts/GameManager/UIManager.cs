using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("User Interface Screens")]
    public Canvas MainMenu;
    public Canvas Upgrade;
    public Canvas GamePlay;
    public Canvas Loose;

    public enum CurrentScreen
    {
        _MainMenu,
        _Upgrade,
        _GamePlay,
        _Pause,
        _Win,
        _Loose
    }
    public CurrentScreen currentState;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuState();
    }

    public void MainMenuState()
    {
        MainMenu.enabled = true;
        GamePlay.enabled = false;
        Upgrade.enabled = false;
        Loose.enabled = false;

        currentState = CurrentScreen._MainMenu;
    }

    public void UpgradeState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = true;
        Loose.enabled = false;

        currentState = CurrentScreen._Upgrade;
    }

    public void GamePlayState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = true;
        Upgrade.enabled = false;
        Loose.enabled = false;

        currentState = CurrentScreen._GamePlay;
    }

    public void LooseState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = false;
        Loose.enabled = true;

        currentState = CurrentScreen._Loose;
    }
}
