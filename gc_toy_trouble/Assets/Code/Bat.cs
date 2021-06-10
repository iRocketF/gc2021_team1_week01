using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public AudioSource swingSound;
    public AudioClipLibrary meleeClips;

    private Animator batAnim;

    public int health = 20;
    public bool isIntact = true;

    void Start()
    {
        batAnim = GetComponent<Animator>();
        swingSound = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            swingSound.pitch = Random.Range(1f, 1.5f);
            swingSound.Play();
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
