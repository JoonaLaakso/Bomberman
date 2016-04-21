using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombPlacementScript : MonoBehaviour {
    public GameObject playerCharacter;
    public GameObject bombPrefab;
    GameObject GM;
    private Vector2 bombSpawnPos;
    public int maxBombs = 1;
    public int bombCount = 1;
    public float bombCD = 1;
    public float tickTime;
    public int bombPower = 3;
    public bool putBomb;

    void Start () {
        bombCount = maxBombs;
        tickTime = bombCD;
        GM = GameObject.Find("GameManager");
        print(GM);
        //GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && bombCount >= 1) {
            putBomb = true;

            //GameObject GM = GameObject.Find("GameManager");
            GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
            //if (gmscript.solidObjects.Count != 0) {
            
            bombSpawnPos = playerCharacter.transform.position;
            float tempX = Mathf.Round(bombSpawnPos.x);
            float tempY = Mathf.Round(bombSpawnPos.y);
            bombSpawnPos = new Vector2(tempX, tempY);
            for (int i = 0; i < gmscript.solidObjects.Count; i++)
                if (gmscript.solidObjects[i] != null && Vector2.Distance(gmscript.solidObjects[i].transform.position, bombSpawnPos) < 0.01f) {
                    putBomb = false;
                } 
            else {
                    putBomb = true;
                }
            //Instantiate(bombPrefab, new Vector2(tempX, tempY), Quaternion.identity);
            if (putBomb == true) {
                GameObject newBomb = Instantiate(bombPrefab, new Vector2(tempX, tempY), Quaternion.identity) as GameObject;
                var script = newBomb.GetComponent<BombDetonate>();
                script.bombLength = bombPower;
                gmscript.solidObjects.Add(newBomb);
                //gmscript.solidObjects.Add((GameObject)Instantiate(bombPrefab, new Vector2(tempX, tempY), Quaternion.identity));
                bombCount--;
            }


        }
        if (bombCount < maxBombs) {
            tickTime -= Time.deltaTime;
            if (tickTime <= 0) {
                while (tickTime <= 0) {
                    tickTime += bombCD;
                    bombCount++;
                }
            }

        }
	
	}
}
