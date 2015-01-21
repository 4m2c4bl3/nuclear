using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    int Lives = 3;
    bool _controlState;
    public static playerStats Player;

    bool controlState 
    {
        get
        {
            return _controlState;
        }

        set
        {
            if (_controlState != value)
            {
                if (_controlState == true)
                {
                    //let player controls be turned back on
                }
                if (_controlState == false)
                {
                    //disable player controls from working
                }
            }

            _controlState = value;
        }

    }

    void Start()
    {
        Player = this;
    }

      public void looseLife ()
    {
           if (Lives > 0)
           {
               controlState = false;
               Lives -= 1;
               //respawn (in controls)
               controlState = true;
           }

           else
           {
               controlState = false;
               //endgame
           }

    }
}