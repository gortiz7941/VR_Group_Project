using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public GameObject helpComponents;
    public GameObject gameSelectionComponents;

    void Start()
    {
        showGameSelectionMenu();
    }

    public void showHelpMenu()
    {
        helpComponents.SetActive(true);
        gameSelectionComponents.SetActive(false);
    }

    public void showGameSelectionMenu()
    {
        helpComponents.SetActive(false);
        gameSelectionComponents.SetActive(true);

    }

}
