using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioClipLibrary meleeClips;

    private Animator batAnim;

    public int health = 20;
    public bool isIntact = true;

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
            UpdateHealth();
        }
    }

    public void UpdateHealth()
    {
        Debug.Log("Health updated");
        health--;

        if (health <= 0)
        {
            isIntact = false;
        }
    }

    public void DestroyBat()
    {
        gameObject.SetActive(false);
    }
}
