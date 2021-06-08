using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private Animator batAnim;


    void Start()
    {
        batAnim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            batAnim.SetTrigger("Swingbat");
        }
    }
}
