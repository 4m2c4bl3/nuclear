using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
    //Manages lives. 
    //Keeps track of the player's last moved direction.
    //can be called as a reference in any other script - use this for something that relates to the player, not the location it's in.
    //call using playerMove.Player.(function or w/e name goes here)
    public int Lives = 5;
    public int maxLives = 5;
    public static playerStats Player;
    public float respawnPause = 2f;
    public float movePause = 0.2f;
    public moveDir lastMove;
    int totalDeaths;
    int lostLives;
    public GameObject spawnPoint;

    //int playerScore;  maybe?

    public enum moveDir { None, Up, Down, Left, Right}
        
    void Awake ()
    {
        Player = this;
    }
    public void isDead ()
    {
        totalDeaths++;
    }

    public void resetLife ()
    {
        Lives = 5;
    }

      public void looseLife ()
    {
           if (Lives > 0)
           {
               Lives -= 1;
               lostLives++;
           }


    }
    void Update ()
      {
        //playerScore = (1000 + 1000/level complete) - (lostlives) - (totalDeathsx100) ?? maybe + for hiting good powerups as well
      }
}