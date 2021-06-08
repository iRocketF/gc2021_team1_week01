using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicObject : MonoBehaviour
{
    public bool wasObjectHit;

    public float colorSwapTime;

    public float attForce;
    public float attCDTimer;
    public float attCoolDown;

    public float health;

    public AudioSource attackSound;

    public Rigidbody rigidBody;
    public Renderer colorMat;

    public Vector3 playerPos;
    public GameObject player;

    void Start()
    {
        wasObjectHit = false;
        colorMat = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
        attackSound = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (wasObjectHit && colorSwapTime < 1)
        {
            colorSwapTime = colorSwapTime + Time.deltaTime / 2;
            colorMat.material.color = Color.Lerp(Color.white, Color.red, colorSwapTime);
        }

        if (wasObjectHit)
        {
            attCDTimer = attCDTimer + Time.deltaTime;
            if (attCDTimer >= attCoolDown)
            {
                JumpPlayer();
                attackSound.Play();
                attCDTimer = 0f;
            }
        }



        CheckPlayerPos();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            health--;
            wasObjectHit = true;
            if(health <= 0)
            {
                Die();
            }
        }
    }

    void JumpPlayer()
    {
        attackSound.PlayOneShot(attackSound.clip);
        rigidBody.AddForce((playerPos - transform.position) * attForce);
    }

    void CheckPlayerPos()
    {
        playerPos = player.transform.position;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
