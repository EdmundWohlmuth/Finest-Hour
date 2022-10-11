using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject UImanager;
    private UIManager UI;

    // Start is called before the first frame update
    void Start()
    {
        UImanager = GameObject.Find("GameManager/UIManager");
        UI = UImanager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MenuState();
    }

    void MenuState()
    {
        switch (UI.currentState)
        {
            case UIManager.CurrentScreen._MainMenu:

                Time.timeScale = 1;
                UI.MainMenuState();

                break;
            case UIManager.CurrentScreen._Upgrade:

                Time.timeScale = 1;
                UI.UpgradeState();

                break;
            case UIManager.CurrentScreen._GamePlay:

                Time.timeScale = 1;
                UI.GamePlayState();

                break;
            case UIManager.CurrentScreen._Pause:
                break;
            case UIManager.CurrentScreen._Win:
                break;
            case UIManager.CurrentScreen._Loose:
                break;
            default:
                break;
        }
    }
}
