using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float Speed = 30f;
    float Horizontal = 0f;
    bool Jump = false;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }
    }
    void FixedUpdate()
    {
        controller.Move(Horizontal * Time.deltaTime, false, Jump);
        Jump = false;
    }
}
