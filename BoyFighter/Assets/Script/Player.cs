using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 30f, maxSpeed=3f, maxJump=4, jumpPow = 250f;
    public bool grounded = true, faceright = true, doubleJump = false;
    public int currentHP;
    public int maxHP = 5;

    public Rigidbody2D boy;  
    public Animator anim;  

    // Start is called before the first frame update
    void Start()
    {
        //Get all the elements from the right category: Animator, Riridbody (for the main character)
        boy = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //set the type bool for variable name "Grounded" into the name "grounded"(for the script)
        anim.SetBool("Grounded", grounded);

        //Set the float value into the variable
        anim.SetFloat("Speed", Mathf.Abs(boy.velocity.x));

        //When player hit Spcebar, the character jump
        if (Input.GetKeyDown(KeyCode.Space)){
            //check if the character is on the ground and the player hit Spce, if yes, AddForce will make the character go up in y axis
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
        //Move the character when the player hit "A-D" or "Left-Right Arrow"
        float h = Input.GetAxis("Horizontal");
        //Add the force to the character, but only in the horizontal axis. (h is always be 1 in this case)
        boy.AddForce((Vector2.right) * speed * h);

        //limit the speed 
        //If the velocity if the character in x axis is bigger than maxSpeed(3)
        if (boy.velocity.x > maxSpeed){
            boy.velocity = new Vector2(maxSpeed, boy.velocity.y);
        }
         if (boy.velocity.x < -maxSpeed){
            boy.velocity = new Vector2(-maxSpeed, boy.velocity.y);
        }

        if (boy.velocity.x > maxJump){
            boy.velocity = new Vector2(boy.velocity.x, maxJump);
        }
         if (boy.velocity.x < -maxJump){
            boy.velocity = new Vector2(boy.velocity.x, -maxJump);
        }

        //to check if the character is not faceright, and the player hit D or Right Arrow (to move right)
        if(h>0 && !faceright){
            //Flip the image of the character
            Flip();
        }
        if(h<0 && faceright){
            Flip();
        }
    
        if(grounded){
            boy.velocity = new Vector2(boy.velocity.x * 0.7f, boy.velocity.y);
        }
        if(currentHP<=0){
            Death();
        }
    }

    //Flip the image of the character(for the character controller)
    //For example: if he faceright but the player hit the "Left Arrow" to go left, the image is flipped
    public void Flip(){  
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        
    }

    public void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.GetComponent<Animation>().Play("fall_right");
    }

    public void Damage(int damage){
        currentHP -= damage;
        gameObject.GetComponent<Animation>().Play("redflash");
    }

    public void Knockback(float knockPow, Vector2 knockDirection){
        boy.velocity = new Vector2(0,0);
        boy.AddForce(new Vector2(knockDirection.x * -100, knockDirection.y + knockPow));
    }
}
