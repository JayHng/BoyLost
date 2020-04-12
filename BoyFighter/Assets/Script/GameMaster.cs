using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{
    public int points = 0;
    public int highscore = 0;
    public Text pointTxt;
    public Text Hightext;
    public Text Inputtext;
    // Start is called before the first frame update
    void Start()
    {
        Hightext.text = (" " + PlayerPrefs.GetInt("highscore"));
        highscore = PlayerPrefs.GetInt("highscore", 0);

        if(PlayerPrefs.HasKey("points")){
            Scene ActiveScene = SceneManager.GetActiveScene(); 
            if(ActiveScene.buildIndex == 0 ){
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else{
            points = PlayerPrefs.GetInt("points");
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        pointTxt.text = (" " + points);
    }
}
