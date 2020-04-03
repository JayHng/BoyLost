using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxSpeed=3f, jumpPow = 220f;

    public Rigidbody2D boy;    
    // Start is called before the first frame update
    void Start()
    {
        boy = gameObject.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        boy.AddForce((Vector2.right) * speed * h);

        if (boy.velocity.x > maxSpeed){
            boy.velocity = new Vector2(maxSpeed, boy.position.y);
        }
         if (boy.velocity.x < -maxSpeed){
            boy.velocity = new Vector2(-maxSpeed, boy.position.y);
        }
    }
}
