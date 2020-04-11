﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Player player;
    public float lifetime = 2;
    // Start is called before the first frame update
    void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

private void OnTriggerEnter2D(Collider2D col) {
    // check if the box collider is triggered or not
    //because the bullet could destroy when it hits the shootPoint collider, not the player
    if(col.isTrigger == false){
        if(col.CompareTag("Player")){
            col.SendMessageUpwards("Damage", 1);
        }
        Destroy(gameObject);
    }
}

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <=0){
            Destroy(gameObject);
        }
    }
}
