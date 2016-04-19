using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {
    public float speed = 1.0f;

    private Vector3 endpos;
    private bool moving = false;

    void Start() {
        endpos = transform.position;
    }

    void Update() {
        if (moving && (transform.position == endpos))
            moving = false;

        if (!moving && Input.GetKey(KeyCode.W)) {
            moving = true;
            endpos = transform.position + Vector3.up;
        }

        if (!moving && Input.GetKey(KeyCode.S)) {
            moving = true;
            endpos = transform.position + Vector3.down;
        }

        if (!moving && Input.GetKey(KeyCode.A)) {
            moving = true;
            endpos = transform.position + Vector3.left;
        }

        if (!moving && Input.GetKey(KeyCode.D)) {
            moving = true;
            endpos = transform.position + Vector3.right;
        }

        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
    }
}
