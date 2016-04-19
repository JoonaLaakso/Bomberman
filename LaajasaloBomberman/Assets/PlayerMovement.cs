using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
    //CURRENT FUNCTIONALITY;
    //Void Update is 100% done
    //gridlocked Movement is 50% done, does not check collisions yet!
    //this script does not have conditions for checking if there is an object on the way. gameObject CollisionChecker will be used for this

    //TODO: Better movement system (no checker object, just checks coordinates from list)
    public float playerSpeed = 3f;
    //public float hz;
    //float hz is currently just for testing
    //private Vector3 moveDirection;
    //Vector3 moveDirection is currently just for testing
    private Vector2 playerPos;
    private Vector2 detectorPos;
    private Vector2 currentPos;
    public GameObject collisionChecker;
    private Vector2 colCheckPos;
    private float adjustFloat = 0f;
    enum Direction { Up, Right, Down, Left, None };
    bool willWeMove;
    Direction moveDir;
    GameObject GM;
    // Use this for initialization
    void Start () {
        playerPos = gameObject.transform.position;
        GM = GameObject.Find("GameManager");
    }

    void Update () {
        //Here we detect which direction the player has pressed using getkey
        //TODO: Use Input.GetAxis instead of KeyCodes (enables multiplayer functionality)
        //TODO: Buffering
        if (Input.GetKey(KeyCode.RightArrow)) {
            moveDir = Direction.Right;

        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            moveDir = Direction.Left;

        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            moveDir = Direction.Up;

        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            moveDir = Direction.Down;

        }
        else {
            moveDir = Direction.None;

        }
        

        //Lets move the object, we want it to stay in the grid! This is the reason we'll be using Mathf.Round (rounds floats, 6.3 goes 6.0, 6.7 goes 7.0 for example)
        if (moveDir != Direction.None){
            Movement();
        }

    }
    void CheckSpot() {
        GameManagerScript gmscript = GM.GetComponent<GameManagerScript>();
        //if (gmscript.solidObjects.Count != 0) {
            for (int i = 0; i < gmscript.solidObjects.Count; i++)
                if (gmscript.solidObjects[i] != null && Vector2.Distance(gmscript.solidObjects[i].transform.position, collisionChecker.transform.position) < 0.1f) {
                    willWeMove = false;
                }
        //}

    }

    void Movement() {
        //TODO: Detect if spot is in a place where you cant go
        //DONE: Grid Movement
        willWeMove = true;
       
        playerPos = gameObject.transform.position;
        currentPos = playerPos;
        colCheckPos = collisionChecker.transform.position;
        float tempX = Mathf.Round(playerPos.x);
        float tempY = Mathf.Round(playerPos.y);
        //float tempCheckX = Mathf.Round(colCheckPos.x + 0.5f);
        //float tempCheckY = Mathf.Round(colCheckPos.y + 0.5f);

        if (moveDir == Direction.Right) {

            //TEST: If collision stuff works
            colCheckPos = new Vector2(playerPos.x + 1f, playerPos.y);
            collisionChecker.transform.position = colCheckPos;
            CheckSpot();
            //IT ends here, remove if statement for willwemove if doesnt
            if (willWeMove != false) {
                //checks if between these coordinates, now were checking the Y (Vertically) axis
                if (playerPos.y > (tempY - 0.1) && playerPos.y < (tempY + 0.1)) {
                    //Going LEFT in this case, set it to rounded coordinates too with Mathf.Round(float)!
                    //script done, Gridlock works, still no collision checking!!
                    if (playerPos.y != Mathf.Round(playerPos.y)) {
                        playerPos = new Vector2(playerPos.x, tempY);
                    } else {
                        playerPos += new Vector2(playerSpeed * Time.deltaTime, 0);
                    }
                }
                //checks if smaller than rounded coordinate
                else if (playerPos.y + adjustFloat < tempY) {
                    //We're going UP here
                    playerPos += new Vector2(0, playerSpeed * Time.deltaTime);
                }
                //checks if bigger than rounded coordinate
                else if (playerPos.y - adjustFloat > tempY) {
                    //We're going DOWN here
                    playerPos += new Vector2(0, -playerSpeed * Time.deltaTime);
                }
            }
            else {
                playerPos = new Vector2(tempX, playerPos.y);
            }
        }
        if (moveDir == Direction.Left) {
            //anim.SetInteger("state", 5);
            //TEST: If collision stuff works
            colCheckPos = new Vector2(playerPos.x - 1f, playerPos.y);
            collisionChecker.transform.position = colCheckPos;
            CheckSpot();
            //IT ends here, remove if statement for willwemove if doesnt
            if (willWeMove != false) {
                //checks if between these coordinates, now were checking the Y (Vertically) axis
                if (playerPos.y > (tempY - 0.1) && playerPos.y < (tempY + 0.1)) {
                    //We're going LEFT in this case, set it to rounded coordinates too with Mathf.Round(float)!
                    if (playerPos.y != Mathf.Round(playerPos.y)) {
                        playerPos = new Vector2(playerPos.x, tempY);
                    } else {
                        playerPos += new Vector2(-playerSpeed * Time.deltaTime, 0);
                    }
                }
            //checks if smaller than rounded coordinate
            else if ((playerPos.y + adjustFloat) < tempY) {
                    //We're going UP here
                    playerPos += new Vector2(0, playerSpeed * Time.deltaTime);
                }
            //checks if bigger than rounded coordinate
            else if ((playerPos.y - adjustFloat) > tempY) {
                    //We're going DOWN here
                    playerPos += new Vector2(0, -playerSpeed * Time.deltaTime);
                }
            }
            else {
                playerPos = new Vector2(tempX, playerPos.y);
            }
        }
        if (moveDir == Direction.Up) {
            //anim.SetInteger("state", 1);
            //TEST: If collision stuff works
            colCheckPos = new Vector2(playerPos.x, playerPos.y + 1f);
            collisionChecker.transform.position = colCheckPos;
            CheckSpot();
            if (willWeMove != false) {
                //IT ends here, remove if statement for willwemove if doesnt
                //checks if between these coordinates, now were checking the X (Horizontally) axis
                if (playerPos.x > (tempX - 0.1) && playerPos.x < (tempX + 0.1)) {
                    if (playerPos.x != Mathf.Round(playerPos.x)) {
                        playerPos = new Vector2(tempX, playerPos.y);
                    } else {
                        playerPos += new Vector2(0, playerSpeed * Time.deltaTime);
                    }
                    //TODO: we need to go UP in this case, set it to rounded coordinates too with Mathf.Round(float)!
                }
            //checks if smaller than rounded coordinate
            else if ((playerPos.x + adjustFloat) < tempX) {
                    //We go RIGHT in this case
                    playerPos += new Vector2(playerSpeed * Time.deltaTime, 0);
                }
            //checks if bigger than rounded coordinate
            else if ((playerPos.x - adjustFloat) > tempX) {
                    //We go LEFT in this case
                    playerPos += new Vector2(-playerSpeed * Time.deltaTime, 0);
                }
            } else {
                playerPos = new Vector2(playerPos.x, tempY);
            }
        }
        if (moveDir == Direction.Down) {
            //anim.SetInteger("state", 3);
            //TEST: If collision stuff works
            colCheckPos = new Vector2(playerPos.x, playerPos.y - 1f);
            collisionChecker.transform.position = colCheckPos;
            CheckSpot();
            if (willWeMove != false) {
                //checks if between these coordinates, now were checking the X (Horizontally) axis
                if (playerPos.x > (tempX - 0.1) && playerPos.x < (tempX + 0.1)) {
                    if (playerPos.x != Mathf.Round(playerPos.x)) {
                        playerPos = new Vector2(tempX, playerPos.y);
                    } else {
                        playerPos += new Vector2(0, -playerSpeed * Time.deltaTime);
                    }

                    //TODO: we need to go DOWN in this case, set it to rounded coordinates too with Mathf.Round(float)!
                }
            //checks if smaller than rounded coordinate
            else if ((playerPos.x + adjustFloat) < tempX) {
                    //We go RIGHT in this case
                    playerPos += new Vector2(playerSpeed * Time.deltaTime, 0);
                }
            //checks if bigger than rounded coordinate
            else if ((playerPos.x - adjustFloat) > tempX) {
                    //We go LEFT in this case
                    playerPos += new Vector2(-playerSpeed * Time.deltaTime, 0);
                }
            } else {
                playerPos = new Vector2(playerPos.x, tempY);
            }
        }
        if (currentPos != playerPos) {
            gameObject.transform.position = playerPos;
        }
        //tempX > (tempX - 0.2) && tempX < (tempX + 0.2)) 

    }
    }

