using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameUI;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerStartPosition;
     
    void Start()
    {
        ShowMainMenu();
    }

    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
        EventManager.onPlayerDeath += ShowMainMenu;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
        EventManager.onPlayerDeath -= ShowMainMenu;
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);

        Instantiate(playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
    }
}
