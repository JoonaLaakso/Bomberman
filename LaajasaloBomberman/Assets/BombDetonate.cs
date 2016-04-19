using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombDetonate : MonoBehaviour {
    public int bombLength = 3;
    public float bombTimer = 3f;
    Vector2 bombInitPos;
    //List<int> Directions;
    List<int> Directions = new List<int>();

    // Use this for initialization
    void Start () {
        //Make a list for all 4 directions for the bomb explosion
        for (int i = 0; i < 4; i++) {
            Directions.Add(0);
            

        }
        //debug
        print(Directions[0]);
        print(Directions[2]);
        print(Directions[3]);
	}
	
	// Update is called once per frame
	void Update () {
        bombTimer -= Time.deltaTime;
        if (bombTimer <= 0) {
            Explosion();
            }
        }
    void Explosion() {
        //Koodia
        //here we have to make bomb explosion logic. Create a center bomb object, then loop all four direction for bomblength amount. 
        //If there is a solid object in front, then for that direction do not create new explosion sprites.
        //if we hit a player, bomb sprite keeps going but we run the death script from the player. 
        //bomb center uses sprite #1, extensions use sprite #2 and where bomb ends we use sprite #3

    }
}


