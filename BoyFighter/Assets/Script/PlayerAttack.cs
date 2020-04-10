using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Each 0.3s, player can attack
    public float attackDelay = 0.3f;

    // the p;layer is attacking
    public bool isAttack = false;
    public Animator anim;

    //check the trigger
    public Collider2D trigger;

    //Awake wil run before void Start
    private void Awake(){
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled =false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the player hit Q and is not attacking, then Attack.
        if(Input.GetKeyDown(KeyCode.Q) && !isAttack){
            isAttack = true;
            trigger.enabled = true;
            attackDelay = 0.3f;    
        }

        //avoid player hit Attack too many times
        if(isAttack){
            if(attackDelay > 0){
                attackDelay -= Time.deltaTime;
            }else{
                isAttack = false;
                trigger.enabled=false;
            }
        }
        anim.SetBool("isAttacking", isAttack);
    }
}
