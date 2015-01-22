using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
    //Manages lives. Pretty simple! Can be used for a score later? Perhaps?
    public int Lives = 3;
    public int maxLives = 3;
    public static playerStats Player;
    
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