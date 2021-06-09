using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeddy : MonoBehaviour
{
    public ScoreSystem scoreSys;
    public float scoreAmount;
    public GameObject brokenVersion;

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
            brokenVersion.transform.position = transform.position;
            brokenVersion.transform.rotation = transform.rotation;
            brokenVersion.SetActive(true);
            gameObject.SetActive(false);

        }
    }

}
