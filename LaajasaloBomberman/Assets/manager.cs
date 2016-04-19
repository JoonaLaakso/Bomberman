using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Kun nuolinäppäimiä painetaan, animaatio siirtyy animaatiosta toiseen.
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            anim.SetInteger("state", 1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            anim.SetInteger("state", 3);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            anim.SetInteger("state", 2);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            anim.SetInteger("state", 5);


    }

}
