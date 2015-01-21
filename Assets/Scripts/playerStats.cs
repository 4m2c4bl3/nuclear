using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    public int Lives = 3;
    public static playerStats Player;
    
    void Awake()
    {
        Player = this;
    }

    public void resetLife (int maxlives)
    {
        Lives = maxlives;
    }

      public void looseLife ()
    {
           if (Lives > 0)
           {
               Lives -= 1;               
           }


    }
}