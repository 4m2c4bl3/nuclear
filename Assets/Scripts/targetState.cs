using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {

    public bool red;
    public bool orange;
    public bool yellow;
    public bool green;
    public bool blue;
    public bool purple;

    void redActive () 
    {
        playerStats.Player.looseLife();
    }

    void orangeActive()
    {
        //something else
    }

    void yellowActive ()
    {
        //etc
    }

    void greenActive()
    {
        //etc
    }
    void blueActive()
    {
        //etc
    }
    void purpleActive()
    {
        //etc
    }
}
