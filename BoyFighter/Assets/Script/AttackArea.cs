using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    //Call class TurretAI 
    public TurretAI turret;

    //if the player is in the left
    public bool isLeft = false; 

    private void Awake() {
        //Inherit all the component in class TurretAI 
        turret = gameObject.GetComponentInParent<TurretAI>();
    }

    private void OnTriggerStay2D(Collider2D col) {
        if(col.CompareTag("Player")){
            if(isLeft){
                //Method Arrack(bool isRight) in TurretAI
                //if the player is on the left, then method Attack is false
                turret.Attack(false);
            }else{
                turret.Attack(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
