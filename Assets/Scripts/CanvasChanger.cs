using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    private GameObject healthText;
    private GameObject healthBar;

    private GameObject attackDamageText;
    private GameObject speedMovementText;

    private float timer;



    private float width;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        healthText = GameObject.FindGameObjectWithTag("HealthText");
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");

        attackDamageText = GameObject.FindGameObjectWithTag("AttackDamageText");
        speedMovementText = GameObject.FindGameObjectWithTag("SpeedMovementText");

        timer = 0f;


    }

    // Update is called once per frame
    void Update()
    {
        changeMovementSpeed();
        changeHealth();
        changeAttack();
        //timer += Time.deltaTime;
    }

    private void changeMovementSpeed()
    {
        speedMovementText.GetComponent<Text>().text = player.GetComponent<PlayerMovement>().speed.ToString();
    }

    private void changeAttack()
    {
        attackDamageText.GetComponent<Text>().text = player.GetComponent<PlayerMovement>().attackDamage.ToString();
    }

    private void changeHealth()
    {
        if (player.GetComponent<PlayerMovement>().health <= 0)
        {
            healthText.GetComponent<Text>().text = "0%";
            healthBar.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
        }
        else
        {
            healthText.GetComponent<Text>().text = player.GetComponent<PlayerMovement>().health.ToString() + "%";
            healthBar.GetComponent<RectTransform>().localScale = new Vector3(player.GetComponent<PlayerMovement>().health / 100, 1, 1);
        }
    }
}
