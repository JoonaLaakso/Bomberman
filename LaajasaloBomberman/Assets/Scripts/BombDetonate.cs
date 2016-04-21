using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombDetonate : MonoBehaviour {
    public int bombLength = 2;
    public float bombTimer = 3f;
    Vector2 bombInitPos;
    Vector2 exploSpot;
    public GameObject bombCenterPrefab;
    public GameObject bombConnectorPrefab;
    public GameObject bombEndPrefab;
    GameObject bombSprite;
    GameObject GM;
    //List<int> Directions;
    List<bool> Directions = new List<bool>();

    // Use this for initialization
    void Start () {
        GM = GameObject.Find("GameManager");
        //Make a bool list for all 4 directions for the bomb explosion
        for (int i = 0; i < 4; i++) {
            Directions.Add(false);
            

        }
        
	}
	
	// Update is called once per frame
	void Update () {
        bombTimer -= Time.deltaTime;
        if (bombTimer <= 0) {
            Explosion();
            }
        }
    public void Explosion() {
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
        -make the loop check 4 different directions (up, down left right with x, -x, y, -y)*/


        
        bombInitPos = gameObject.transform.position;
        Instantiate(bombCenterPrefab, bombInitPos, Quaternion.identity);
        float tempX = Mathf.Round(bombInitPos.x);
        float tempY = Mathf.Round(bombInitPos.y);
        GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
        for (int i = 0; i < bombLength; i++) {

            //TODO; Every other direction and check the up part
            int n = 0;
            //lets check up
            if (Directions[n] != true) {
                bombSprite = bombConnectorPrefab;
                exploSpot = new Vector2(tempX, tempY + i + 1);
                Vector2 newExploSpot = new Vector2(tempX, tempY + i + 2);
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, exploSpot) < 0.1f) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                if (i == bombLength - 1) {
                    bombSprite = bombEndPrefab;
                }
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, newExploSpot) < 0.1f && gmscript.solidObjects[k].name.Contains("HardBlock")) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                Instantiate(bombSprite, exploSpot, Quaternion.Euler(0, 0, 90));
                
                
            }
            n++;
            //lets check right
            if (Directions[n] != true) {
                bombSprite = bombConnectorPrefab;
                exploSpot = new Vector2(tempX + i + 1, tempY);
                Vector2 newExploSpot = new Vector2(tempX + i + 2, tempY);
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, exploSpot) < 0.1f) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                if (i == bombLength - 1) {
                    bombSprite = bombEndPrefab;
                }
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, newExploSpot) < 0.1f && gmscript.solidObjects[k].name.Contains("HardBlock")) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                Instantiate(bombSprite, exploSpot, Quaternion.Euler(0, 0, 0));

            
            }
            n++;
            //lets check down
            if (Directions[n] != true) {
                bombSprite = bombConnectorPrefab;
                exploSpot = new Vector2(tempX, tempY - i - 1);
                Vector2 newExploSpot = new Vector2(tempX, tempY - i - 2);
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, exploSpot) < 0.1f) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                if (i == bombLength - 1) {
                    bombSprite = bombEndPrefab;
                }
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, newExploSpot) < 0.1f && gmscript.solidObjects[k].name.Contains("HardBlock")) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                Instantiate(bombSprite, exploSpot, Quaternion.Euler(0, 0, 270));

            
            }
            n++;
            //lets check left
            if (Directions[n] != true) {
                bombSprite = bombConnectorPrefab;
                exploSpot = new Vector2(tempX - i - 1, tempY);
                Vector2 newExploSpot = new Vector2(tempX - i - 2, tempY);
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, exploSpot) < 0.1f) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                if (i == bombLength - 1) {
                    bombSprite = bombEndPrefab;
                }
                for (int k = 0; k < gmscript.solidObjects.Count; k++)
                    if (gmscript.solidObjects[k] != null && Vector2.Distance(gmscript.solidObjects[k].transform.position, newExploSpot) < 0.1f && gmscript.solidObjects[k].name.Contains("HardBlock")) {
                        Directions[n] = true;
                        bombSprite = bombEndPrefab;
                    }
                Instantiate(bombSprite, exploSpot, Quaternion.Euler(0, 0, 180));

            
            }
            n++;
        }
        /*

        #2 make explosions;
        explosion objects need a is a trigger collider with a script which checks if ontriggerenter happens (for players, also might need a list for players)
        loop logic; check if spot is either a block or a free spot. for soft blocks; create end particle on them. For hard blocks, create end particle before them.
        This can be easily done if we check the spot before making the prefab to the spot.

        if we want to go right for example on the 2nd loop, we do:
        first check if flameEnd(direction) = false

        exploSpot =  vector2(tempx + i + 1, tempy)
        if left:
        exploSpot = vector2(tempx - i + 1, tempy)
        if up:
        exploSpot = vector2(tempx, tempy + i + 1)
        etcetera

        if this spot is populated with a soft block, then we use sprite #3 (rotate it!) and turn on flameEnd(left right etc whatever we need) = true

        If not, we use sprite #2. Rotate it right!
        

        after this, either of these happen;
        first check if flameEnd(direction) = false

        ïf we reach a dead end;
        -check next (hard) block with 
        if we go right:
        checkSpot = vector2(tempx + i, tempy)
        etc
        if we reach i = bomblength,

        we instantiate a sprite #3 (Rotate it!) on current exploSpot, turn on flameEnd(left right up down etc whatever we need) = true


        */

        Destroy(gameObject);
    }
}


