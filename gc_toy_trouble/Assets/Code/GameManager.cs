using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float roundLength;
    public float gameTimer;
    public float gameEndTimer;

    public bool hasRoundStarted;
    public bool isRoundActive;
    public bool isMimicAlive;
    public bool isPlayerDead;

    public bool hasDeathSoundPlayed;

    public GameObject mimic;
    public GameObject player;
    public Bat bat;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bat = GameObject.FindObjectOfType<Bat>();

        isRoundActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMimicAlive && !hasRoundStarted)
            FindMimic();

        if (isMimicAlive)
            CheckIfMimicAlive();

        if (isRoundActive && isMimicAlive)
            GameClock();

        if(!isMimicAlive && hasRoundStarted)
            if (Input.GetButtonDown("Restart"))
                Restart();

        if (!bat.isIntact)
            DestroyBat();

        if (gameTimer >= roundLength && isMimicAlive)
        {
            isPlayerDead = true;

            if (!hasDeathSoundPlayed)
            {
                PlayDeathSound();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    void GameClock()
    {
        if (gameTimer < roundLength)
            gameTimer = gameTimer + Time.deltaTime;
    }

    void FindMimic()
    {
        mimic = FindObjectOfType<MimicObject>().gameObject;
        isMimicAlive = true;
        hasRoundStarted = true;
    }

    void CheckIfMimicAlive()
    {
        if (mimic == null)
        {
            isMimicAlive = false;
            isRoundActive = false;
        }
    }

    void DestroyBat()
    {
        isPlayerDead = true;

        if (!hasDeathSoundPlayed)
            PlayDeathSound();

        bat.DestroyBat();
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void PlayDeathSound()
    {
        AudioSource goreSound = player.AddComponent<AudioSource>();
        AudioSource deathSound = player.GetComponent<AudioSource>();
        goreSound.clip = Resources.Load<AudioClip>("Sounds/deathsplatter");
        goreSound.PlayOneShot(goreSound.clip, 0.7f);
        deathSound.PlayOneShot(deathSound.clip, 0.5f);
        hasDeathSoundPlayed = true;
    }
}
