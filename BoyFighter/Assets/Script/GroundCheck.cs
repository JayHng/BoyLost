using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D other) {
        player.grounded = true;

    }
    private void OnTriggerExit2D(Collider2D collider) {
        player.grounded = false;

    }
}
