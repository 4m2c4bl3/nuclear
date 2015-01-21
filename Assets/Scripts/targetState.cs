using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {

   public int Status = 1;
   Timer buffer = new Timer();

    void Start ()
   {
       buffer.setTimer(3);
   }
    
    void Update ()
    {
        if (gameObject.GetComponent<playerMove>().isActive == true && buffer.Ok() == true)
        {
            switch (Status)
            {
                case 1:
                    //blank & safe
                    break;
                case 2:
                    buffer.setTimer(3);
                    playerStats.Player.looseLife();
                    Debug.Log("ow!");
                    break;                
                
            }
        }
    }

   
}
