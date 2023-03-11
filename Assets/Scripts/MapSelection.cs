using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private GameObject greenWay;
    [SerializeField] private GameObject snowyVillage;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mapSelectionMenu;

    public void selectGreenWay()
    {
        snowyVillage.SetActive(false);
        greenWay.SetActive(true);
        activateMainMenu();
    }

    public void selectSnowyVillage()
    {
        greenWay.SetActive(false);
        snowyVillage.SetActive(true);
        activateMainMenu();
    }

    private void activateMainMenu()
    {
        mainMenu.SetActive(true);
        mapSelectionMenu.SetActive(false);
    }
    
}
