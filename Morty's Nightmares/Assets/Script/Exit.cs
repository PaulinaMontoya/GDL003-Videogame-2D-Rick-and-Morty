//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void FinishGame ()
    {
        Application.Quit();
        Debug.LogError("The game has finished");
    }
}
