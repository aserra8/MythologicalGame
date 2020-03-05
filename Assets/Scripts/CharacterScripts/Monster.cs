using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update

    public string name;
    public string description;
    public float health;
    public float attackDamage;
    public float attackRange;
    public float cooldownAttack;
    protected float cooldwonAttackTimer;
    public float movementSpeed;
    public float rotationSpeed;
    public int hitNumber;

    protected Animator animator;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
