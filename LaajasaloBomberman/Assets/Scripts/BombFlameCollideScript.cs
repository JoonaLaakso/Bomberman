using UnityEngine;
using System.Collections;

public class BombFlameCollideScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c) {


        if (c.name == "Player") {
            c.GetComponent<PlayerExterminate>().DestroyThis();
        }
        if (c.name.Contains("SoftBlock")) {
            c.GetComponent<SoftBlockDestroyAndPowerUp>().DestroyThis();
        }
        if (c.name.Contains("BombObject")) {
            print("touched bomb");
            c.GetComponent<BombDetonate>().Explosion();
        }
    }
}