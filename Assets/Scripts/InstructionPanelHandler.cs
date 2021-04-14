using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanelHandler : MonoBehaviour
{

    public GameObject[] panels;
    private Button previousButton;
    private Button nextButton;
    private Button backButton;
    private int currentPanel = 0;

    // Start is called before the first frame update
    void Start()
    {
        setButtons();
    }

    private void setButtons() {
        foreach (Button button in GetComponents<Button>()) {
            if (button.name == "Previous") {
                previousButton = button;
            } else if (button.name == "BackToMenu") {
                backButton = button;
            } else if (button.name == "Next") {
                nextButton = button;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
