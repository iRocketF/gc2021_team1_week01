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

    public float soundTimer;
    public float soundCD = 15f;

    // amount of score for killing the mimic
    public float score;

    public AudioSource mimicSound;

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
        mimicSound = GetComponent<AudioSource>();
        mimicSound.spatialBlend = 1f;

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
                mimicSound.Play();
                attCDTimer = 0f;
            }
        }

        if (soundTimer < soundCD)
            soundTimer = soundTimer + Time.deltaTime;

        if (soundTimer >= soundCD)
            PlayTell();

        CheckPlayerPos();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            health--;
            wasObjectHit = true;
            mimicSound.clip = Resources.Load<AudioClip>("Sounds/mimicaggro");
            mimicSound.pitch = 1f;
            mimicSound.Play();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void PlayTell()
    {
        mimicSound.clip = Resources.Load<AudioClip>("Sounds/mimicbreath");
        mimicSound.Play();
        soundTimer = 0f;
    }

    void JumpPlayer()
    {
        // roar and attack the player by jumping at them
        mimicSound.clip = Resources.Load<AudioClip>("Sounds/mimicgrowl");
        mimicSound.pitch = 3f;
        mimicSound.Play();
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
