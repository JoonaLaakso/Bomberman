﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombPlacementScript : MonoBehaviour {
    public GameObject playerCharacter;
    public GameObject bombPrefab;
    GameObject GM;
    private Vector2 bombSpawnPos;
    public int maxBombs;
    public int bombCount = 1;
    public float bombCD = 1;
    public float tickTime;
    public int bombPower = 3;

    void Start () {
        maxBombs = bombCount;
        GM = GameObject.Find("GameManager");
        print(GM);
        //GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && bombCount >= 1) {
            //GameObject GM = GameObject.Find("GameManager");
            GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
            bombSpawnPos = playerCharacter.transform.position;
            float tempX = Mathf.Round(bombSpawnPos.x);
            float tempY = Mathf.Round(bombSpawnPos.y);
            //Instantiate(bombPrefab, new Vector2(tempX, tempY), Quaternion.identity);
            gmscript.solidObjects.Add((GameObject)Instantiate(bombPrefab, new Vector2(tempX, tempY), Quaternion.identity));
            bombCount--;


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
