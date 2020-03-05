using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float attackCounter;
    private float cooldownAttack;

    private String spriteWereWolfName;
    private String spriteNumber;

    public GameObject attackNormal;
    public GameObject attackFinal;

    private int hitCount;

    private enum AttackDirection
    {
        left,
        right,
        up,
        down
    }

    private AttackDirection attackDirection;

    // Start is called before the first frame update
    void Start()
    {
        cooldownAttack = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().cooldownAttack;
        attackCounter = 8.0f;
        hitCount = 10;
    }

    // Update is called once per frame
    void Update()
    {

        attackCounter += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && attackCounter >= cooldownAttack)
        {
            attack();
            if (attackCounter >= cooldownAttack)
            {
                attackCounter = 0.0f;
            }
        }

    }

    private void attack()
    {
        attackDirectionMethod();

        GameObject attackSpawn;
        GameObject attackInstantiate;

        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().hitNumber < hitCount)
        {
            attackInstantiate = attackNormal;
            hitCount++;
        } 
        else
        {
            attackInstantiate = attackFinal;
            hitCount = 0;
        }

        switch (attackDirection)
        {
            case AttackDirection.up:
                attackSpawn = Instantiate(attackInstantiate, new Vector3(transform.position.x, transform.position.y + .8f, 0), Quaternion.identity);
                attackSpawn.GetComponent<WereWolfAttack>().damage = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().attackDamage;
                break;
            case AttackDirection.down:
                attackSpawn = Instantiate(attackInstantiate, new Vector3(transform.position.x, transform.position.y - .8f, 0), Quaternion.identity);
                attackSpawn.GetComponent<WereWolfAttack>().damage = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().attackDamage;
                break;
            case AttackDirection.left:
                attackSpawn = Instantiate(attackInstantiate, new Vector3(transform.position.x - .8f, transform.position.y, 0), Quaternion.identity);
                attackSpawn.GetComponent<WereWolfAttack>().damage = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().attackDamage;
                break;
            case AttackDirection.right:
                attackSpawn = Instantiate(attackInstantiate, new Vector3(transform.position.x + .8f, transform.position.y, 0), Quaternion.identity);
                attackSpawn.GetComponent<WereWolfAttack>().damage = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().attackDamage;
                break;
            default:
                attackSpawn = Instantiate(attackInstantiate, new Vector3(transform.position.x, transform.position.y - .8f, 0), Quaternion.identity);
                attackSpawn.GetComponent<WereWolfAttack>().damage = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().attackDamage;
                break;
        }


    }

    private void attackDirectionMethod()
    {
        spriteWereWolfName = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite.ToString();
        spriteNumber = spriteWereWolfName.Split('_')[1].Split(' ')[0];

        if (spriteNumber.Equals("0") || spriteNumber.Equals("7") || spriteNumber.Equals("15") || spriteNumber.Equals("24"))
        {
            attackDirection = AttackDirection.left;
        }
        else if (spriteNumber.Equals("2") || spriteNumber.Equals("5") || spriteNumber.Equals("17") || spriteNumber.Equals("26"))
        {
            attackDirection = AttackDirection.right;
        }
        else if (spriteNumber.Equals("1") || spriteNumber.Equals("8") || spriteNumber.Equals("16") || spriteNumber.Equals("25"))
        {
            attackDirection = AttackDirection.down;
        }
        else
        {
            attackDirection = AttackDirection.up;
        }

    }
}
