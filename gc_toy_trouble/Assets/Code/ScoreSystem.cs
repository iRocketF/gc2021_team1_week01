using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float startingScore;
    public float score;

    void Start()
    {
        score = startingScore;
    }

    void Update()
    {
        
    }

    public void AddScore(float addedScore)
    {
        score = score + addedScore;
    }
}
