using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public MovingPla mov;
    public Player player;
    public Vector3 movingplat;

    // Start is called before the first frame update
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("MovingPlat").GetComponent<MovingPla>();
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision) {
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        // if(collision.isTrigger == false && collision.CompareTag("MovingPlat"))
        // {
        //     movingplat = player.transform.position;
        //     movingplat.x = mov.speed * 1.3f;
        //     player.transform.position = movingplat;
        // }
       player.grounded = true;

    }
    private void OnTriggerExit2D(Collider2D collision) {
        player.grounded = false;
    }
}
