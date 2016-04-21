using UnityEngine;
using System.Collections;

public class PlayerExterminate : MonoBehaviour {

    public AudioClip[] deathSound;

    private AudioSource sound;


    public void DestroyThis () {

        sound = GetComponent<AudioSource>();
        int ran = Random.Range(0, 8);
        sound.clip = deathSound[ran];
        sound.Play();
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<BombPlacementScript>().enabled = false;
        gameObject.GetComponent<PlayerExterminate>().enabled = false;
    }


}
