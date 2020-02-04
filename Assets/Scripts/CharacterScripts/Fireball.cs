using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update

   
    public float damage;
    private float timer;
    
    void Start()
    {
        timer = 0.0f;   
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 5.0f)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisio");
        if (collision.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerMovement>().health -= this.damage;
            Destroy(this.gameObject);
        }
    }
}
