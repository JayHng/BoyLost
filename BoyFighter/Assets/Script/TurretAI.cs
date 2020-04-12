using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int curHealth = 100;
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 5;
    public float bulletTimer;
    
    public bool awake;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointL, shootPointR;

    public SoundManager sound;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);

        RangeCheck();

        //check the status of turret, if the target position is on the right of turret -> lookRight
        if(target.transform.position.x > this.transform.position.x){
            lookingRight = true;
        }
        //If the target position is on the left of turret -> lookRight is false
        if(target.transform.position.x < this.transform.position.x){
            lookingRight = false;
        }
        //Destroy when HP <= 0
        if(curHealth < 0 ){
            sound.playSound("destroy");
            Destroy(gameObject);
        }
    }
    void RangeCheck(){
        //Calculate the distance between target(Player) and Turret
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance < wakeRange){
            awake = true;
        }
        if(distance > wakeRange)
        {
            awake = false;  
        }
    }
    public void Attack(bool attackright){
        //Increase bases on Realtime
        bulletTimer += Time.deltaTime; 

        if(bulletTimer >= shootInterval){
            //Determine the direction of the bullet
            Vector2 direction = target.transform.position - transform.position;
            //Make this vection have the magnitude of 1
            direction.Normalize();

            //if the direction is right, shoot the bullet in the right
            if(attackright){
                GameObject bulletClone;
                //clone new bullet at the shootPointR position and the rotate bases on shootPointR rotation
                bulletClone = Instantiate(bullet,shootPointR.transform.position, shootPointR.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0; 
            }

            //if the direction is not right, shoot the bullet in the left
            if(!attackright){
                GameObject bulletClone;
                //clone new bullet at the shootPointL position and the rotate bases on shootPoinLR rotation
                bulletClone = Instantiate(bullet,shootPointL.transform.position, shootPointL.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0; 
            }
        }
    }

    public void Damage(int dmg){
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("redflash");
    }
    
}
