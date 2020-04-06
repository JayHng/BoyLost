using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxSpeed=3f, jumpPow = 220f;
    public bool grounded = true, faceright = true, doubleJump = false;
    public int currentHP;
    public int maxHP = 5;

    public Rigidbody2D boy;  
    public Animator anim;  
    // Start is called before the first frame update
    void Start()
    {
        boy = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(boy.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space)){
            if (grounded){
                grounded=false;
                doubleJump = true;
                boy.AddForce(Vector2.up * jumpPow);
            }
            else{
                if(doubleJump){
                    doubleJump = false;
                    boy.velocity = new Vector2 (boy.velocity.x, 0);
                    boy.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        boy.AddForce((Vector2.right) * speed * h);

        if (boy.velocity.x > maxSpeed){
            boy.velocity = new Vector2(maxSpeed, boy.velocity.y);
        }
         if (boy.velocity.x < -maxSpeed){
            boy.velocity = new Vector2(-maxSpeed, boy.velocity.y);
        }
        if(h>0 && !faceright){
            Flip();
        }
        if(h<0 && faceright){
            Flip();
        }
        if(grounded){
            boy.velocity = new Vector2(boy.velocity.x * 0.7f, boy.velocity.y);
        }
        if(currentHP<0){
            Death();
        }
    }

    public void Flip(){  
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        
    }

    public void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
