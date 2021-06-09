using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float roundLength;

    public float gameTimer;

    public bool isRoundActive;

    void Start()
    {
        isRoundActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
            GameClock();
    }

    void GameClock()
    {
        if (gameTimer < roundLength)
        {

            gameTimer = gameTimer + Time.deltaTime;
        }
    }
}
