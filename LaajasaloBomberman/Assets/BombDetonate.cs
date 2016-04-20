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

        /*#1 Init:
        create the center mass of the bomb, set up a loop. For the loop we need these variables:
        -initial location
        -temp variables for every direction (simple as only one vector2 variable), these might have to be rounded
        -bool to check for each direction (list of 4)
        -make the loop check 4 different directions (up, down left right with x, -x, y, -y)

        #2 make explosions;
        explosion objects need a is a trigger collider with a script which checks if ontriggerenter happens (for players, also might need a list for players)
        loop logic; check if spot is either a block or a free spot. for soft blocks; create end particle on them. For hard blocks, create end particle before them.
        This can be easily done if we check the spot before making the prefab to the spot.

        if we want to go right for example on the 2nd loop, we do:
        exploSpot =  vector2(tempx + i, tempy)
        if left:
        exploSpot = vector2(tempx - i, tempy)
        if up:
        exploSpot = vector2(tempx, tempy + i)
        */


    }
}


