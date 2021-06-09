using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicSpawner : MonoBehaviour
{
    public List<GameObject> scoreObjects;

    void Start()
    {
        scoreObjects = new List<GameObject>();

        // create list of all scoreObjects in the scene
        foreach (var scoreObject in GameObject.FindGameObjectsWithTag("ScoreObject"))
        {
            scoreObjects.Add(scoreObject);
        }

        // choose a random object to be converted into a mimic
        int mimicNum = Random.Range(0, (scoreObjects.Count - 1));

        // add a mimic script to the chosen gameobject
        scoreObjects[mimicNum].AddComponent<MimicObject>();

        // add sounds to the mimic without using prefabs
        // this could probably be done easier with prefabs, but this is an experiment :D
        // also changes the name of the object to "mimic" for easy recognition
        AudioSource mimic_audioSource = scoreObjects[mimicNum].AddComponent<AudioSource>();
        mimic_audioSource.clip = Resources.Load<AudioClip>("Sounds/mimicgrowl");
        mimic_audioSource.pitch = 3f;

        scoreObjects[mimicNum].name = "Mimic";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
