using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectionTextLoader : MonoBehaviour
{
    public Text carpentryTitle;
    public Text carpentryDescription;
    public Text carpentryHelpTitle;
    public Text carpentryHelpDescription;

    public Text electricalTitle;
    public Text electricalDescription;
    public Text electricalHelpTitle;
    public Text electricalHelpDescription;

    public Text plumbingTitle;
    public Text plumbingDescription;
    public Text plumbingHelpTitle;
    public Text plumbingHelpDescription;

    void Start()
    {
        carpentryTitle.text = "Carpentry";
        carpentryDescription.text = "Live a day in the life of a carpenter. Drywall needs to be installed by hanging on the wall and screwing in.";
        carpentryHelpTitle.text = "Carpentry Help";
        carpentryHelpDescription.text = "Pick up drywall by pointing and pulling your trigger finger. Place the drywall on the wall by releasing your trigger finger.";

        electricalTitle.text = "Electrical";
        electricalDescription.text = "Live a day in the life of a electrician. Electrical boxes need to be installed, and wires need to be run through the walls.";
        electricalHelpTitle.text = "Electrical Help";
        electricalHelpDescription.text = "Pick up wires and electrical objects by pulling your trigger finger. Place the wires by releasing your trigger finger.";

        plumbingTitle.text = "Plumbing";
        plumbingDescription.text = "Live a day in the life of a plumber. Pipes need to be hooked up to a water supply, and run through the walls.";
        plumbingHelpTitle.text = "Plumbing Help";
        plumbingHelpDescription.text = "Pick up pipes by pulling your trigger finger. Rotate the pipes by pressing the A button. Place them by releasing your trigger finger.";
    }

}
