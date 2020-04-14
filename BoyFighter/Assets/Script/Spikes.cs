using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        //if the collider of the spike touch thing wwil the tag "Player", take damage and move to new position(Knockback)
        if(col.CompareTag("Player")){
            player.Damage(damage);
            player.Knockback(10f, player.transform.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
