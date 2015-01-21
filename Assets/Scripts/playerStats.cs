using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    int Lives = 3;
    bool _controlState;
    
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
            else
            {

            }

            _controlState = value;
        }

    }

}
