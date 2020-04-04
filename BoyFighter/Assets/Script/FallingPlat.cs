using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player")){
            StartCoroutine(fall());
        }
    }

    IEnumerator fall(){
        yield return new WaitForSeconds(timeDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
