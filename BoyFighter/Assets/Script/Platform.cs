using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   /// <summary>
   /// Sent each frame where a collider on another object is touching
   /// this object's collider (2D physics only).
   /// </summary>
   /// <param name="other">The Collision2D data associated with this collision.</param>
   private void OnCollisionStay2D(Collision2D col)
   {
       if(col.collider.CompareTag("Player")){
           if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
               gameObject.GetComponent<Collider2D>().enabled = false;
           }

       }
   }

   private void OnCollisionExit2D(Collision2D col) {
       if(col.collider.CompareTag("Player")){
           Invoke("Restore", 0.5f);
       }
   }

   void Restore(){
       gameObject.GetComponent<Collider2D>().enabled = true;
   }
}
