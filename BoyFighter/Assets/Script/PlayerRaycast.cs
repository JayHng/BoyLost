using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    //
    public float shootDelay = 0, damage = 20;

    //the line hits a specific layer that we attach
    public LayerMask whatToHit;

    /// shot point
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        //determine the "ShootPOint" tag that we already created in the engine
        firePoint = transform.Find("shootPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //increase the shootDelay by real time
        shootDelay += Time.deltaTime;
        shot();
        //when shootDelay >= 0.5 and the player hits left mouse, reset the shootdDelay; reset shootDelay and plau function shot()
        if(shootDelay >= 0.5f){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                shootDelay =0;
                shot();
            }
        }
    }
    void shot(){
        Debug.Log("Shot");

        // take the point from camera  
        Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        //set the shot point position
        Vector2 firepointpos = new Vector2 (firePoint.position.x, firePoint.position.y);

        //start shotting the line (invisible)
        RaycastHit2D hit = Physics2D.Raycast(firepointpos, (mousePos - firepointpos), 10, whatToHit);
        Debug.DrawLine(firepointpos, (mousePos - firepointpos)*100, Color.cyan);

//ì the line hit anythign with collider
        if(hit.collider != null)
        {
            Debug.DrawLine(firepointpos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name);
        }
    }
}
