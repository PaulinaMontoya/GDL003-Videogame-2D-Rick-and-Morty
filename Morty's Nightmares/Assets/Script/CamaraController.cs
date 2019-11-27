using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour{

    public Transform Morty;
    public float offset = 6f;

    /*
    void Start(){
    }  
    */
    
    void Update(){

        if (Morty == null)
        return;

         transform.position = new Vector3 ( Morty.position.x + offset, transform.position.y, transform.position.z );
    }
}
