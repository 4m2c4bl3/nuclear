using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {
    //Tells the target what effects it should do.
   public int Status = 1;
   Timer buffer = new Timer();
   //float damageTick = 3f;
   GameObject upTarget;
   GameObject downTarget;
   GameObject leftTarget;
   GameObject rightTarget;
   GameObject teleportOption;
   public Color c1 = new Color32(58, 58, 58, 255);
   public Color c2 = new Color32(99, 199, 141, 255);
   public Color c3 = new Color32(189, 95, 195, 255);
   public Color c4 = new Color32(95, 125, 195, 255);

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
    public void  applyEffects()
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
                //damage when you first land on it. parts marked out made it a DOT effect, we can use one or both options.
                //buffer.setTimer(damageTick);
                playerStats.Player.looseLife();
                Debug.Log("ow!");
                break;
            case 4:
                //double push
                doublePush(); //THIS IS BROKEN RIGHT NOW SORRY!!!!!!!!!!!
                break;
            case 5:
                //pushback
                //(if Player.playerMove.lastMove == "up")
                //gameObject.GetComponent<playerMove>().moveTo(downTarget);
                break;
            case 6:
                //random teleport :s
                //generate random > http://answers.unity3d.com/questions/300880/choose-a-random-game-object-based-on-tag.html ?
                // if random.targetState.Status == 0 then redo ^
                // else gameObject.playerMove.isActive = false && random.playerMove.isActive = true
                break;
            case 7:
                //non-random teleport
                //gameObject.playerMove.isActive = false && teleport.playerMove.isActive = true
                break;
            case 8:
                //slow or speed movement
                //just increase/decrease the delay of playerStats.Player.playerMove
                break;

        }
    }
    void doublePush ()
    {
        if (playerStats.Player.lastMove == "left" && gameObject.GetComponent<playerMove>().canMove(leftTarget) == true)
        {
            gameObject.GetComponent<playerMove>().moveTo(leftTarget);
        }
        if (playerStats.Player.lastMove == "right" && gameObject.GetComponent<playerMove>().canMove(rightTarget) == true)
        {
            gameObject.GetComponent<playerMove>().moveTo(rightTarget);
        }
        if (playerStats.Player.lastMove == "up" && gameObject.GetComponent<playerMove>().canMove(upTarget) == true)
        {
            gameObject.GetComponent<playerMove>().moveTo(upTarget);
        }
        if (playerStats.Player.lastMove == "down" && gameObject.GetComponent<playerMove>().canMove(downTarget) == true)
        {
            gameObject.GetComponent<playerMove>().moveTo(downTarget);           
        }
    }
    void resetColor()
    {
        switch (Status)
        {
            case 1:
                //inactive default grey
                renderer.material.SetColor("_Color", c1);
                break;

            case 2:         
                //active safe green
                renderer.material.SetColor("_Color", c2);
                break;

            case 3:
                //special effect
                renderer.material.SetColor("_Color", c3);
                break;

            case 4:
                //special effect
                renderer.material.SetColor("_Color", c4);
                break;
        }
    }
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Refreshing colors.");
            resetColor();
        }

        //if (gameObject.GetComponent<playerMove>().isActive == true && buffer.Ok() == true)
       // {
            //applyEffects();
       // }
    }

   
}
