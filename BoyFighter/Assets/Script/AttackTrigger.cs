using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dam = 20;

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.isTrigger != true && col.CompareTag("Enemy")){
            //SendMessageUpwards is the method that belong to Unity framework. 
            //SendMessageUpwards call the function "Damage" that I already created in TurretAI
            col.SendMessageUpwards("Damage",dam);
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
