using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolfAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    private float count;

    void Start()
    {
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count > 0.3f)
        {
            Destroy(this.gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Enemy") && collision.GetType().ToString().Equals("UnityEngine.CircleCollider2D"))
        {
            Debug.Log("Has ferit l'aranya.");
            collision.GetComponent<EnemyScript>().health -= this.damage;
            Destroy(this.gameObject);
        }
    }
}
