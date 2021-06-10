using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicObject : MonoBehaviour
{
    public bool wasObjectHit;

    public float colorSwapTime;

    // these are hard coded because of not creating prefabs;
    // going to try creating editable parts for the spawner script
    // that are then applied to the mimic object upon creation
    public float attForce = 150f;
    public float attCDTimer = 0f;
    public float attCoolDown = 2f;
    public float health = 3f;

    // amount of score for killing the mimic
    public float score;

    public AudioSource attackSound;

    public Rigidbody rigidBody;
    public Renderer colorMat;

    public Vector3 playerPos;
    public GameObject player;

    private ScoreSystem scoreSys;

    void Start()
    {
        wasObjectHit = false;
        colorMat = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
        attackSound = GetComponent<AudioSource>();

        scoreSys = FindObjectOfType<ScoreSystem>();
    }

    void Update()
    {
        // this part checks if the object was hit and then aggroed
        // object turns red to indicate this is the mimic
        if (wasObjectHit && colorSwapTime < 1)
        {
            colorSwapTime = colorSwapTime + Time.deltaTime / 2;
            colorMat.material.color = Color.Lerp(Color.white, Color.red, colorSwapTime);
        }

        // upon getting hit, this part starts the attacking timer
        // everytime the timer hits the cooldown, the mimic attacks by lunging at the player
        // TODO: some sort of damage/health to the player
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
            attackSound.clip = Resources.Load<AudioClip>("Sounds/mimicaggro");
            attackSound.pitch = 1f;
            attackSound.Play();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void JumpPlayer()
    {
        // roar and attack the player by jumping at them
        attackSound.clip = Resources.Load<AudioClip>("Sounds/mimicgrowl");
        attackSound.pitch = 3f;
        attackSound.Play();
        rigidBody.AddForce((playerPos - transform.position) * attForce);
    }

    void CheckPlayerPos()
    {
        playerPos = player.transform.position;
    }

    void Die()
    {
        // ded
        scoreSys.score = scoreSys.score + score;
        Destroy(gameObject);
    }
}
