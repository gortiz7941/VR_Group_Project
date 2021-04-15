using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// this is from https://answers.unity.com/questions/878667/world-space-canvas-on-top-of-everything.html?_ga=2.267606158.1699211322.1616262284-1657948343.1604615341

public class WorldSpaceOverlayUI : MonoBehaviour
{
    private const string shaderTestMode = "unity_GUIZTestMode"; //The magic property we need to set
    [SerializeField] UnityEngine.Rendering.CompareFunction desiredUIComparison = UnityEngine.Rendering.CompareFunction.Always; //If you want to try out other effects
    [Tooltip("Set to blank to automatically populate from the child UI elements")]
    [SerializeField] Graphic[] uiElementsToApplyTo;
    //Allows us to reuse materials
    private Dictionary<Material, Material> materialMappings = new Dictionary<Material, Material>();
    protected virtual void Start()
    {
        if (uiElementsToApplyTo.Length == 0)
        {
            uiElementsToApplyTo = gameObject.GetComponentsInChildren<Graphic>();
        }
        foreach (var graphic in uiElementsToApplyTo)
        {
            Material material = graphic.materialForRendering;
            if (material == null)
            {
                Debug.LogError($"{nameof(WorldSpaceOverlayUI)}: skipping target without material {graphic.name}.{graphic.GetType().Name}");
                continue;
            }
            if (!materialMappings.TryGetValue(material, out Material materialCopy))
            {
                materialCopy = new Material(material);
                materialMappings.Add(material, materialCopy);
            }
            materialCopy.SetInt(shaderTestMode, (int)desiredUIComparison);
            graphic.material = materialCopy;
        }
    }
}
