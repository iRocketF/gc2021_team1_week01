using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeddy : MonoBehaviour
{
    private GameManager manager;
    public ScoreSystem scoreSys;
    public float scoreAmount;
    public GameObject brokenVersion;

    [SerializeField]
    private bool isMimic;
    private bool isIntact;

    private void Start()
    {
        scoreSys = FindObjectOfType<ScoreSystem>();
        isIntact = true;
    }

    private void Update()
    {
        CheckIfMimic();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (isIntact && !isMimic && collision.gameObject.CompareTag("Weapon"))
        {
            scoreSys.AddScore(scoreAmount);
            isIntact = false;
            brokenVersion.transform.position = transform.position;
            brokenVersion.transform.rotation = transform.rotation;
            brokenVersion.SetActive(true);
            gameObject.SetActive(false);

        }
    }

    void CheckIfMimic()
    {
        if (this.GetComponent<MimicObject>() != null)
            isMimic = true;
        
    }

}
