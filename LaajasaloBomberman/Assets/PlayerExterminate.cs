using UnityEngine;
using System.Collections;

public class PlayerExterminate : MonoBehaviour {
    



    public void DestroyThis () {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<BombPlacementScript>().enabled = false;
        gameObject.GetComponent<PlayerExterminate>().enabled = false;
    }


}
