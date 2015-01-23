using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
    //Manages lives. Pretty simple! Can be used for a score later? Perhaps?
    //Player movespeed and respawn speed.
    public int Lives = 3;
    public int maxLives = 3;
    public static playerStats Player;
    public float respawnPause = 2f;
    public float movePause = 0.5f;
    
    void Awake ()
    {
        Player = this;
    }

    public void resetLife ()
    {
        Lives = maxLives;
    }

      public void looseLife ()
    {
           if (Lives > 0)
           {
               Lives -= 1;               
           }


    }
}