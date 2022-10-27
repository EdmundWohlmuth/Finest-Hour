using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject UIManager;
    public UIManager UI;

    private void Start()
    {
        UIManager = GameObject.Find("GameManager/UIManager");
        UI = UIManager.GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UI.WinState();
        }
    }
}
