using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {
    //Tells the target what effects it should do.
    public statusOptions currentStatus;
   Timer buffer = new Timer();
   //float damageTick = 3f;
   public float speedChange = 0.2f;
   public GameObject lastTarget;
   GameObject teleportOption;
   public Color c1 = new Color32(58, 58, 58, 255);
   public Color c2 = new Color32(99, 199, 141, 255);
   public Color c3 = new Color32(189, 95, 195, 255);
   public Color c4 = new Color32(95, 125, 195, 255);
   public Color c5 = new Color32(195, 138, 95, 255);

    //make new colors for new features by copypasta and editing in the hex codes. (r,g,b,a)
    //assign the colors down in the renderColor function
   public enum statusOptions {Inactive, Safe, Damaging, PushForward, PushBack, ChangeSpeed, Undeveloped }
    void Start ()
   { 
       renderer.material.shader = Shader.Find("Self-Illumin/Diffuse");
       buffer.setTimer(3);
       resetColor();        
   }
    public void  applyEffects()
    {
        if (currentStatus == statusOptions.Damaging)
        {
            //lose one life when moving onto
            playerStats.Player.looseLife();
        }
        if (currentStatus == statusOptions.PushForward)
        {
            //pushes players one more direction forward if possible
            gameObject.GetComponent<playerMove>().pushType = "forward";
            gameObject.GetComponent<playerMove>().movePush(gameObject.GetComponent<playerMove>().pushType); 
        }
        if (currentStatus == statusOptions.PushBack)
        {
            //pushes players back where they came
            gameObject.GetComponent<playerMove>().pushType = "back";
            gameObject.GetComponent<playerMove>().movePush(gameObject.GetComponent<playerMove>().pushType); 
        }
        if (currentStatus == statusOptions.ChangeSpeed)
        {
            //slow or speed movement  0.2f = average
            //we can have this as a timed effect or wears off after x amount of moves
            playerStats.Player.movePause = speedChange;
        }
        if (currentStatus == statusOptions.Undeveloped)
        {
            //random teleport :s
            //generate random > http://answers.unity3d.com/questions/300880/choose-a-random-game-object-based-on-tag.html ?
            // if random.targetState.Status == 0||4||5 then redo ^ (let's not have people be able to teleport on push objects, that's too confusing)
            // else gameObject.playerMove.isActive = false && random.playerMove.isActive = true

            //non-random teleport
            //gameObject.playerMove.isActive = false && teleport.playerMove.isActive = true
        }
     
    }
    void resetColor()
    {

        if (currentStatus == statusOptions.Inactive)
        {
             //inactive default grey
                renderer.material.SetColor("_Color", c1);               
        }
        if (currentStatus == statusOptions.Safe)
        {            
                //active safe green
                renderer.material.SetColor("_Color", c2);
        }
        if (currentStatus == statusOptions.Damaging)
        {
            //special effect
            renderer.material.SetColor("_Color", c3);
        }
        
        if (currentStatus == statusOptions.PushForward)
        {
            //special effect
            renderer.material.SetColor("_Color", c4);
        }
        if (currentStatus == statusOptions.PushBack)
        {
            //special effect
            renderer.material.SetColor("_Color", c5);
        }
        if (currentStatus == statusOptions.ChangeSpeed)
        {

        }
        if (currentStatus == statusOptions.Undeveloped)
        {

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
