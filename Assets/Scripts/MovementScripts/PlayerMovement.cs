﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Monster
{
    public float energy;
    public float speed;
    public VectorValue startingPosition;

    private Vector3 change;
    //private Animator animator;
    private Rigidbody2D myRigidBody;
    public DeathMenuScript deathMenu;
        

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();


        //Set the player position to the starting position when changing scenes
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
<<<<<<< HEAD

        CheckDeath();
=======
        DieAnimation();
    }

    private void DieAnimation()
    {
        if (health <= 0)
        {
            animator.SetBool("dead", true);
        }
>>>>>>> d13d366b53b62f4d303bd14ac94d3782f8c7c9c9
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void CheckDeath()
    {
        if (health <= 0)
        {
            deathMenu.ShowMenu();
        }
    }
}
