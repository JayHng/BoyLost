using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public MovingPla mov;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        //mov = GameObject.FindGameObjectWithTag("MovingPlat").GetComponent<MovingPla>();

        //Get all the component from class Player
        player = gameObject.GetComponentInParent<Player>();
    }

    //when the character hits the ground (when the box collider of our character hits the collider of the ground)
    void OnTriggerEnter2D(Collider2D collision) {
        player.grounded = true;
    }

    //if the character stays in the ground
    private void OnTriggerStay2D(Collider2D collision) {
        // if(collision.isTrigger == false && collision.CompareTag("MovingPlat"))
        // {
        //     movingplat = player.transform.position;
        //     movingplat.x = mov.speed * 1.3f;
        //     player.transform.position = movingplat;
        // }

        player.grounded = true;

    }

    //if the character is not on the ground jump
        private void OnTriggerExit2D(Collider2D collision) {
        player.grounded = false;
    }
}
