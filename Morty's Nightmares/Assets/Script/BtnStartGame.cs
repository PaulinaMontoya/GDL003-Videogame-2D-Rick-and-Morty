using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStartGame : MonoBehaviour
{

    public void StartGame() {
        Application.LoadLevel(0);
    }

}
