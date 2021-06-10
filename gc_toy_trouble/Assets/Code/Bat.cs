using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioClipLibrary meleeClips;

    private Animator batAnim;

    void Start()
    {
        batAnim = GetComponent<Animator>();
        hitSound = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            batAnim.SetTrigger("Swingbat");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ScoreObject"))
        {
             
        }
    }
}
