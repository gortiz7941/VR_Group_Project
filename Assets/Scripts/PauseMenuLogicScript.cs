using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Prefabs.Locomotion.Teleporters;
using Zinnia.Data.Type;

public class PauseMenuLogicScript : MonoBehaviour
{

    public TeleporterFacade teleporter;
    public Transform playArea;
    public Transform headOrientation;
    public Transform pauseLocation;
    public Transform gameLocation;

    protected bool inPauseMenu;

    public List<GameObject> pauseItems;
    public List<GameObject> gameItems;


    public void switchRooms()
    {
        TransformData teleportationDestination = new TransformData(gameLocation);
        if (!inPauseMenu)
        {
            gameLocation.position = playArea.position;
            Vector3 right = Vector3.Cross(playArea.up, headOrientation.forward);
            Vector3 forward = Vector3.Cross(right, playArea.up);
            teleportationDestination = new TransformData(pauseLocation);
        }

        teleporter.Teleport(teleportationDestination);

        inPauseMenu = !inPauseMenu;

        foreach (GameObject item in pauseItems)
        {
            item.setActive(inPauseMenu);
        }

        foreach (GameObject item in pauseItems)
        {
            item.setActive(!inPauseMenu);
        }

    }



}
