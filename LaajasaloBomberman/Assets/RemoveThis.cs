using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveThis : MonoBehaviour {
    //Functionality for removing this block and removing it fromthe list has been implemented!!

    GameObject GM;
    GameObject block;

    //Void Start checks rng on start, then removes this block with this script if number is less than assigned
    void Start() {
        block = gameObject;
        GM = GameObject.Find("GameManager");
        GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
            if (Random.Range(1, 100) < gmscript.randomPercent) {
                for (int i = 0; i < gmscript.solidObjects.Count; i++) {
                    if (gmscript.solidObjects[i] == block) {
                    }
                }
                Destroy(block);
            }
        }
    

    public void DestroyBlock() {
        GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
        //if (gmscript.solidObjects.Count != 0) {
            for (int i = 0; i < gmscript.solidObjects.Count; i++) {
                if (gmscript.solidObjects[i] == block) {
                }
            }
            Destroy(block);
        //}
        


    }
    /*
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GM = GameObject.Find("GameManager");
            GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
            for (int i = 0; i < gmscript.solidObjects.Count; i++) {
                if (gmscript.solidObjects[i] == gameObject) {
                    gmscript.solidObjects.RemoveAt(i);
                }
            }
            Destroy(gameObject);
        }
    }
    */

	
	// Update is called once per frame
	
}
