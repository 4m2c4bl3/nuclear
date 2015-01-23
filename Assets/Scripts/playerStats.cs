using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
    //Manages lives. 
    //Keeps track of the player's last moved direction.
    //can be called as a reference in any other script - use this for something that relates to the player, not the location it's in.
    //call using playerMove.Player.(function or w/e name goes here)
    public int Lives = 3;
    public int maxLives = 3;
    public static playerStats Player;
    public float respawnPause = 2f;
    public float movePause = 0.5f;
    public moveDir lastMove;

    public enum moveDir { None, Up, Down, Left, Right}
        
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