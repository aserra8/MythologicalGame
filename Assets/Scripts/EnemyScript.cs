﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Monster
{
    // Start is called before the first frame update

    private enum EnemyState { 
        patrol,
        detectPlayer,
        attack
    };
    public enum AttackStyle
    {
        distance,
        mele
    };


    private EnemyState enemyState;

    private GameObject playerAttack;
    private Vector3 targetPosition;
    private Vector3 towardTarget;

    public AttackStyle attackStyle;

    public GameObject attackStyleObject;
    public GameObject specialAttackStyleObject;

    private int countHitNumber;


    void Start()
    {
        animator = GetComponent<Animator>();
        enemyState = EnemyState.patrol;
        countHitNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.patrol:

                enemyPatrolAroundMap();

                break;

            case EnemyState.detectPlayer:

                towardTarget = targetPosition - transform.position;

                if (towardTarget.magnitude > attackRange)
                    RecalculateTargetPosition();
                else
                    enemyState = EnemyState.attack;

                //Quaternion towardTargetRotation = Quaternion.LookRotation(towardTarget, Vector3.up);
                //transform.rotation = Quaternion.Lerp(transform.rotation, towardTargetRotation, rotationSpeed * Time.deltaTime);
                //transform.LookAt(targetPosition);
                
                transform.position += towardTarget.normalized * movementSpeed * Time.deltaTime;

                if (Math.Abs(towardTarget.normalized.x) > Math.Abs(towardTarget.normalized.y))
                {
                    animator.SetFloat("MoveX", towardTarget.normalized.x);
                }
                else
                {
                    animator.SetFloat("MoveY", towardTarget.normalized.y);
                }


                break;

            case EnemyState.attack:

                towardTarget = targetPosition - transform.position;

                if (towardTarget.magnitude <= attackRange)
                {
                    RecalculateTargetPosition();
                    if (playerAttack.GetComponent<PlayerMovement>().health > 0)
                    {
                        attackPlayer();
                    }
                }
                else
                    enemyState = EnemyState.detectPlayer;

                break;

            default:
                break;
        }
    }

    private void attackPlayer()
    {
        
        switch (attackStyle)
        {
            case AttackStyle.distance:

                if (cooldownAttack < cooldwonAttackTimer)
                {
                    shot();
                    cooldwonAttackTimer = 0;
                }
                else
                {
                    cooldwonAttackTimer += Time.deltaTime;
                }

                break;

            case AttackStyle.mele:

                break;

            default:

                break;
        }



    }

    private void shot()
    {
        if (countHitNumber < hitNumber)
        {
            GameObject fireballSpawn = Instantiate(attackStyleObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            fireballSpawn.transform.SetParent(this.transform);
            fireballSpawn.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerAttack.transform.position.x - transform.position.x, playerAttack.transform.position.y - transform.position.y), ForceMode2D.Impulse);
            fireballSpawn.GetComponent<Fireball>().damage = attackDamage;
            countHitNumber++;
        }
        else
        {
            GameObject fireballSpawn = Instantiate(specialAttackStyleObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            fireballSpawn.transform.SetParent(this.transform);
            fireballSpawn.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerAttack.transform.position.x - transform.position.x, playerAttack.transform.position.y - transform.position.y), ForceMode2D.Impulse);
            fireballSpawn.GetComponent<Fireball>().damage = attackDamage * 1.25f;
            countHitNumber = 0;
        }
        
    }

    private void RecalculateTargetPosition()
    {
        targetPosition = playerAttack.transform.position;
    }

    private void enemyPatrolAroundMap()
    {
        // AQUÍ FAREM UN CIRCUIT DE MOVIMENT DELS ENEMICS.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerAttack = collision.gameObject;
            targetPosition = playerAttack.transform.position;
            enemyState = EnemyState.detectPlayer;   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemyState = EnemyState.patrol;
        }
    }
}
