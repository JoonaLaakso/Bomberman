using UnityEngine;
using System.Collections;

public class BombFlameCenterCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c) {

        print("Collision");
        if (c.name.Contains("PlayerCharacter")) {
            c.GetComponent<PlayerExterminate>().DestroyThis();
        }
        if (c.name.Contains("SoftBlock")) {
            c.GetComponent<SoftBlockDestroyAndPowerUp>().DestroyThis();
        }
    }

}