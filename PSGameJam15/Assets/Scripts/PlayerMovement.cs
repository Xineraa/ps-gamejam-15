using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float Speed = 30f;
    public float gravity = 1f;
    float Horizontal = 0f;
    bool Jump = false;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
