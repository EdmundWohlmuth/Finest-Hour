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
    public Canvas Save;
    public Canvas Pause;
    public Canvas NewGame;
    public Canvas OverrideSave;
    public Canvas Win;

    public enum CurrentScreen
    {
        _MainMenu,
        _Upgrade,
        _GamePlay,
        _Pause,
        _Win,
        _Loose,
        _SaveGame,
        _NewGame,
        _OverrideSave     
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
        Save.enabled = false;
        Pause.enabled = false;  
        NewGame.enabled = false;
        OverrideSave.enabled = false;
        Win.enabled = false;

        currentState = CurrentScreen._MainMenu;
    }

    public void UpgradeState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = true;
        Loose.enabled = false;
        Save.enabled = false;
        Pause.enabled = false;
        NewGame.enabled = false;
        OverrideSave.enabled = false;
        Win.enabled = false;

        currentState = CurrentScreen._Upgrade;
    }

    public void GamePlayState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = true;
        Upgrade.enabled = false;
        Loose.enabled = false;
        Save.enabled = false;
        Pause.enabled = false;
        NewGame.enabled = false;
        OverrideSave.enabled = false;
        Win.enabled = false;

        currentState = CurrentScreen._GamePlay;
    }

    public void LooseState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = false;
        Loose.enabled = true;
        Save.enabled = false;
        Pause.enabled = false;
        NewGame.enabled = false;
        OverrideSave.enabled = false;
        Win.enabled = false;

        currentState = CurrentScreen._Loose;
    }

    public void SaveState()
    {
        Save.enabled = true;

        currentState = CurrentScreen._SaveGame;
    }

    public void PauseState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = true;
        Upgrade.enabled = false;
        Loose.enabled = false;
        Save.enabled = false;
        Pause.enabled = true;
        NewGame.enabled = false;
        OverrideSave.enabled = false;
        Win.enabled = false;

        currentState = CurrentScreen._Pause;
    }

    public void NewGameState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = false;
        Loose.enabled = false;
        Save.enabled = false;
        Pause.enabled = false;
        NewGame.enabled = true;
        OverrideSave.enabled = false;
        Win.enabled = false;

        currentState = CurrentScreen._NewGame;
    }

    public void OverrideSaveState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = false;
        Loose.enabled = false;
        Save.enabled = false;
        Pause.enabled = false;
        NewGame.enabled = false;
        OverrideSave.enabled = true;
        Win.enabled = false;

        currentState = CurrentScreen._NewGame;
    }

    public void WinState()
    {
        MainMenu.enabled = false;
        GamePlay.enabled = false;
        Upgrade.enabled = false;
        Loose.enabled = false;
        Save.enabled = false;
        Pause.enabled = false;
        NewGame.enabled = false;
        OverrideSave.enabled = false;
        Win.enabled = true;

        currentState = CurrentScreen._Win;
    }
}

