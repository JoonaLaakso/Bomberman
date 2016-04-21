using UnityEngine;
using System.Collections;

public class Animmove : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetInteger("state", 1);
        }
        // GET KEY UP. KUN NAPPIA EI ENÄÄ PAINETA ANIMAATIO PALAA ALKUASETELMAAN, PÄÄ HEILUU
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetInteger("state", 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetInteger("state", 4);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetInteger("state", 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("state", 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("state", 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("state", 3);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("state", 0);
        }
    }
}