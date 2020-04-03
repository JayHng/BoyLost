using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxSpeed=3f, jumpPow = 220f;
    public bool grounded = true, faceright = true;

    public Rigidbody2D boy;  
    public Animator anim;  
    // Start is called before the first frame update
    void Start()
    {
        boy = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(boy.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space)){
            if (grounded){
                grounded=false;
                boy.AddForce(Vector2.up * jumpPow);
            }
        }
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
        if(h>0 && !faceright){
            Flip();
        }
        if(h<0 && faceright){
            Flip();
        }
    }

    public void Flip(){  
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        
    }
}
