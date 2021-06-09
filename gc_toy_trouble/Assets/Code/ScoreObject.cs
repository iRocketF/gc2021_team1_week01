using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    private ScoreSystem scoreSys;
    public float scoreAmount;

    private bool isIntact;

    private void Start()
    {
        isIntact = true;
        scoreSys = FindObjectOfType<ScoreSystem>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (isIntact && collision.gameObject.CompareTag("Weapon"))
        {
            scoreSys.AddScore(scoreAmount);
            isIntact = false;
        }
    }

}
