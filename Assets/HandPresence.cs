using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            Debug.Log("Found Device");

            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            } 
            else
            {
                Debug.Log("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }


            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

        spawnedHandModel.SetActive(true);
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
            Debug.Log("Pressing button");
        }


        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

        if (triggerValue > 0.1f)
        {
            Debug.Log(triggerValue);
        }
    }
}
