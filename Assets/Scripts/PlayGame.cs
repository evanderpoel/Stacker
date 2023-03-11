using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private GameObject gameHandler;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject mapSelection;
    [SerializeField] private GameObject mainMenuSelection;
    
    public void playGame()
    { 
        gameHandler.SetActive(true);
        inGameUI.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void openMapSelection()
    {
        mapSelection.SetActive(true);
        mainMenuSelection.SetActive(false);
    }
    
}
