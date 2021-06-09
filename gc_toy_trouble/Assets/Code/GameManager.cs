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

    public GameObject mimic;

    void Start()
    {
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

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
