using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {
    //Tells the target what effects it should do.
   public int Status = 1;
   Timer buffer = new Timer();
   float damageTick = 3f;
   GameObject leftTarget;
   GameObject rightTarget;
   GameObject upTarget;
   GameObject downTarget;
   public GameObject teleportOption;
   public Color effect0 = new Color32(99, 199, 141, 255);
   public Color effect1 = new Color32(189, 95, 195, 255);
   public Color effect2 = new Color32(95, 125, 195, 255);
   public Color effect3 = new Color32(95, 125, 195, 255);

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
                buffer.setTimer(damageTick);
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

            case 4:
                renderer.material.SetColor("_Color", effect2);
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
