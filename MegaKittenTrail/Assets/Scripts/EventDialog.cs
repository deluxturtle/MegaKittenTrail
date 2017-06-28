using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Andrew Seba
/// Description:
/// A script to find these references easily that belongs on the event dialog object.
/// </summary>
public class EventDialog : MonoBehaviour {


    public Text textBig;
    public Button buttonOk;

    /// <summary>
    /// Displays Dialog box
    /// </summary>
    /// <param name="pText">Info</param>
    public void DisplayDialog(string pText)
    {
        textBig.text = pText;
        gameObject.SetActive(true);
    }
    

    public void DisplayDialog(string pText, bool yesno)
    {
        textBig.text = pText;
        if(yesno == true)
        {
            //TODO Start working on the delagats to let the buttons function
        }
    }
}
