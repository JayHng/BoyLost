using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPla : MonoBehaviour
{
    public float speed = 0.04f, changeDirection = -1;
    Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move.x += speed;
        this.transform.position = Move;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.collider.CompareTag("Ground")){
            speed *= changeDirection;
        }
    }
}
