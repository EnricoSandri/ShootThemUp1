using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteprefs : MonoBehaviour
{

	//This example creates a button on the screen that if pressed, deletes any PlayerPrefs settings.
//You must set values or keys in the PlayerPrefs first to see this in action.




    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

