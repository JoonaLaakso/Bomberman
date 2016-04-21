using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {
    public List<GameObject> solidObjects;
    public int randomPercent = 5;
    //The only use of this is to make the list for blocks.

    void Start() {
        solidObjects.AddRange(GameObject.FindGameObjectsWithTag("Solid"));
        

    }


}
