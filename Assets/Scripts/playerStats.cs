using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
    //Manages lives. 
    //Keeps track of the player's last moved direction.
    //can be called as a reference in any other script - use this for something that relates to the player, not the location it's in.
    //call using playerMove.Player.(function or w/e name goes here)
    public float Lives = 5;
    public float totalLives = 5;
    public float maxLives = 5;
    public static playerStats Player;
    public float respawnPause = 2f;
    public float movePause = 0.2f;
    public moveDir lastMove;
    int lostLives;
    public GameObject spawnPoint;
    public bool menuOpen = false;
    public bool Lost = true;

    //int playerScore;  maybe?

    public enum moveDir { None, Up, Down, Left, Right}
        
    void Awake ()
    {
        Player = this;
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
          public void gameOver()
          {
              if (totalLives <= 0)
              {
                  Lost = true;
              }
              else
              {
                  Lost = false;
              }

              Application.LoadLevel("end_scene");

          }

  
    void Update ()
      {
          if (totalLives <= 0)
        {
            gameOver();

        }
        //playerScore = (1000 + 1000/level complete) - (lostlives) - (totalDeathsx100) ?? maybe + for hiting good powerups as well
      }
}