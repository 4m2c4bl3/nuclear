using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {
    //Tells the target what effects it should do.
   public int Status = 1;
   Timer buffer = new Timer();
   public Color effect0;
   public Color effect1;
   GameObject leftTarget;
   GameObject rightTarget;
   GameObject upTarget;
   GameObject downTarget;

    void Start ()
   {
       leftTarget = gameObject.GetComponent<playerMove>().leftTarget;
       rightTarget = gameObject.GetComponent<playerMove>().rightTarget;
       upTarget = gameObject.GetComponent<playerMove>().upTarget;
       downTarget = gameObject.GetComponent<playerMove>().downTarget;

       renderer.material.shader = Shader.Find("Self-Illumin/Diffuse");
       buffer.setTimer(3);
       resetColor();        
   }
    void  applyEffects()
    {
        switch (Status)
        {
            case 1:
                //cannot pass onto this square
                break;
            case 2:
                //safe to pass through, no effect
                break;
            case 3:
                buffer.setTimer(3);
                playerStats.Player.looseLife();
                Debug.Log("ow!");
                break;
            case 4:
                //double push
                if (playerStats.Player.lastMove == "left")
                {
                    gameObject.GetComponent<playerMove>().moveTo(leftTarget);
                    break;
                }
                if (playerStats.Player.lastMove == "right")
                {
                    gameObject.GetComponent<playerMove>().moveTo(rightTarget);
                    break;
                }
                if (playerStats.Player.lastMove == "up")
                {
                    gameObject.GetComponent<playerMove>().moveTo(upTarget);
                    break;
                }
                if (playerStats.Player.lastMove == "down")
                {
                    gameObject.GetComponent<playerMove>().moveTo(downTarget);
                    break;
                }
                    break;

        }
    }

    void resetColor()
    {
        switch (Status)
        {
            case 1:
                //inactive, no color
                break;

            case 2:               
                renderer.material.SetColor("_Color", effect0);
                break;

            case 3:
                renderer.material.SetColor("_Color", effect1);
                break;
        }
    }
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            resetColor();
        }

        if (gameObject.GetComponent<playerMove>().isActive == true && buffer.Ok() == true)
        {
            applyEffects();
        }
    }

   
}
