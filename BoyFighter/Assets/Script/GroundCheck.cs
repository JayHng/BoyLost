using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public MovingPla movingplat;
    public Player player;

    public Vector3 movep;

    // Start is called before the first frame update
    void Start()
    {
        movingplat = GameObject.FindGameObjectWithTag("MovingPlat").GetComponent<MovingPla>();

        //Get all the component from class Player
        player = gameObject.GetComponentInParent<Player>();
    }

    //when the character hits the ground (when the box collider of our character hits the collider of the ground)
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.isTrigger == false){
            player.grounded = true;
        }
    }

    //if the character stays in the ground
    private void OnTriggerStay2D(Collider2D collision) { 
        if(collision.isTrigger == false || collision.CompareTag("water"))
        {
            player.grounded = true;    
        }

        if(collision.isTrigger == false && collision.CompareTag("MovingPlat"))
        {
            movep = player.transform.position;
            movep.x += movingplat.speed/2;
            player.transform.position = movep;
        }


    }

    //if the character is not on the ground
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.isTrigger == false || collision.CompareTag("water"))
        {
            player.grounded = false;
        }
    }
}
