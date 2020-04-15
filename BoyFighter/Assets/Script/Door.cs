using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int LevelLoad = 1;
    public GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")){
            saveScore();       
            gm.Inputtext.text = ("Press E to enter");
        }
    }
    private void OnTriggerStay2D(Collider2D col) {
        if(col.CompareTag("Player")){
            if(Input.GetKey(KeyCode.E)){
                saveScore();
                SceneManager.LoadScene(LevelLoad);
            }
        }  
    }
    private void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("Player")){
            //Display "Press E to Enter"
            gm.Inputtext.text = ("");
        }
    }

    void saveScore(){
        PlayerPrefs.SetInt("points", gm.points);
    }
}
