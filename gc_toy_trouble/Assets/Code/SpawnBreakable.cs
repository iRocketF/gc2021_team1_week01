using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBreakable : MonoBehaviour
{
    public GameObject brokenVersion;
    public Vector3 objectPos;
    public Quaternion rotationPos;
    private GameManager manager;
    public ScoreSystem scoreSys;

    public float scoreAmount;

    [SerializeField]
    private bool isMimic;
    private bool isIntact;

    private void Start()
    {
        scoreSys = FindObjectOfType<ScoreSystem>();
        objectPos = transform.position;
        rotationPos = transform.rotation;
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

            Instantiate(brokenVersion, objectPos, rotationPos);

            Destroy(gameObject);

        }
    }

    void CheckIfMimic()
    {
        if (this.GetComponent<MimicObject>() != null)
            isMimic = true;

    }
}
