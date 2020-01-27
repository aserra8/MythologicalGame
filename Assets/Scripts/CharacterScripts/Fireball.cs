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
        timer = 5.0f;   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
