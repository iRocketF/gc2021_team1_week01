using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public ScoreSystem scoreSys;
    public float scoreAmount;

    private bool isIntact;

    private void Start()
    {
        isIntact = true;
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
