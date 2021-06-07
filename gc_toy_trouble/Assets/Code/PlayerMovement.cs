using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private new Camera camera;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float crouchSpeed = 4f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private bool isCrouching = false;
    public float crouchHeight = 0.4f;
    private Vector3 standingPos;
    private Vector3 crouchPos;

    private float crouchTime = 10f;
    private float currentLerpTime;

    private void Start()
    {
        standingPos = camera.transform.localPosition;
        crouchPos = camera.transform.localPosition;
        crouchPos.y = crouchHeight;
    }

    void Update()
    {
        UpdateMovement();
        Crouch();
    }

    void UpdateMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (!isCrouching)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * crouchSpeed * Time.deltaTime);
        }
        
        // Gravity checks
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
            currentLerpTime = 0f;
        }

        Vector3 currentPos = camera.transform.localPosition;

        if (isCrouching)
        {
            float lerpPercent = 0f;

            if (lerpPercent <= 1f && crouchPos.y < camera.transform.localPosition.y)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > crouchTime)
                {
                    currentLerpTime = crouchTime;
                }

                lerpPercent = currentLerpTime / crouchTime;
                camera.transform.localPosition = Vector3.Lerp(currentPos, crouchPos, lerpPercent);
            }
        }
        else
        {
            float lerpPercent = 0f;

            if (lerpPercent <= 1f && standingPos.y > camera.transform.localPosition.y)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > crouchTime)
                {
                    currentLerpTime = crouchTime;
                }

                lerpPercent = currentLerpTime / crouchTime;
                camera.transform.localPosition = Vector3.Lerp(currentPos, standingPos, lerpPercent);
            }
        }
    }
}
