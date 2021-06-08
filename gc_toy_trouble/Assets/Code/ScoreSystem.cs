using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float score;
    public float scoreMultiplier;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(float addedScore)
    {
        score = score + addedScore;
    }
}
