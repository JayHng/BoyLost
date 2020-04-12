using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, swords, destroy;

    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("Game coin");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("Rock Crash");
        audioSrc = GetComponent<AudioSource>();
    }

    public void playSound(string clip){
        switch(clip){
            case "coins":
                audioSrc.clip = coins;
                audioSrc.PlayOneShot(coins, 0.6f);
                break;

            case "destroy":
                audioSrc.clip = destroy;
                audioSrc.PlayOneShot(destroy, 1f);
                break;

            case "sword":
                audioSrc.clip = swords;
                audioSrc.PlayOneShot(swords, 1f);
                break;

            
        }
    }
}
