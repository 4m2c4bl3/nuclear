using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {
    //Tells the target what effects it should do.
   [HideInInspector]
   public statusOptions currentStatus;
   Timer buffer = new Timer();
   //float damageTick = 3f;
   public float speedChange = 0.2f;
   [HideInInspector]
   public GameObject lastTarget;
   GameObject teleportOption;
   [HideInInspector]
   public Color timerColor;
    [HideInInspector]
   public Color setMe;
    [HideInInspector]
   public Color setMe2;
    [HideInInspector]
   public Color setMe3;
   public Color spawnMe = new Color32(102, 156, 86, 255);
   public Color saveMe = new Color32(179, 179, 179, 255);
   public Color Inactive = new Color32(58, 58, 58, 255);
   public Color Safe = new Color32(59, 255, 0, 255);
   public Color Damaging = new Color32(239, 0, 112, 255);
   public Color PushForward = new Color32(84, 255, 253, 255);
   public Color PushBack = new Color32(250, 255, 15, 255);
   public Color LeftBumper = new Color32(219, 136, 39, 255);
   public Color RightBumper = new Color32(132, 41, 144, 255);

    public Color doesntChange = new Color32(255, 255, 255, 255);
    public Color zeroPointThree = new Color32(188, 188, 188, 255);
    public Color zeroPointFive = new Color32(112, 112, 112, 255);
    public Color zeroPointEight = new Color32(67, 67, 67, 255);
    public Color one = new Color32(20, 20, 20, 255);
   [HideInInspector]
   public string nextLevelName = null;
   bool savePoint = false;
   statusOptions altStatus;
   statusOptions altStatus2;
   statusOptions altStatus3;
   public float timerLength;
   Timer length = new Timer();

    
   public enum statusOptions {Inactive, Safe, TheEnd, Damaging, PushForward, PushBack, LeftBumper, RightBumper, ChangeSpeed, Undeveloped }
    void Start ()
   { 
       renderer.material.shader = Shader.Find("Self-Illumin/Diffuse");
       buffer.setTimer(3);
       setStatus();
       resetColor();        
   }

    void setTimer()
    {
        if (timerColor == doesntChange)
        {

        }
        else if (timerColor == zeroPointThree)
        {
            timerLength = 0.3f;
        }
        else if (timerColor == zeroPointFive)
        {
            timerLength = 0.5f;
        }
        else if (timerColor == zeroPointEight)
        {
            timerLength = 0.8f;
        }
        else if (timerColor == one)
        {
            timerLength = 1f;
        }
    }
    void setStatus()
    {
        if (setMe == saveMe)
        {
            savePoint = true;
            currentStatus = statusOptions.Safe;
            altStatus = statusOptions.Safe;
        }
        if (setMe == spawnMe)
        {
            startGame.startG.spawnPoint = gameObject;
            gameObject.GetComponent<playerMove>().isActive = true;
            currentStatus = statusOptions.Safe;
            altStatus = statusOptions.Safe;
        }
        if (setMe == Inactive)
        {
            currentStatus = statusOptions.Inactive;
            altStatus = statusOptions.Inactive;
        }
        if (setMe2 == Inactive)
        {
            altStatus2 = statusOptions.Inactive;
        }
        if (setMe3 == Inactive)
        {
            altStatus3 = statusOptions.Inactive;
        } 
        if (setMe == Safe)
        {
            currentStatus = statusOptions.Safe;
            altStatus = statusOptions.Safe;
        }
        if (setMe2 == Safe)
        {
            altStatus2 = statusOptions.Safe;
        }
        if (setMe3 == Safe)
        {
            altStatus3 = statusOptions.Safe;
        } 
        if (setMe == Damaging)
        {
            currentStatus = statusOptions.Damaging;
            altStatus = statusOptions.Damaging;
        }
        if (setMe2 == Damaging)
        {
            altStatus2 = statusOptions.Damaging;
        }
        if (setMe3 == Damaging)
        {
            altStatus3 = statusOptions.Damaging;
        }  
        if (setMe == PushForward)
        {
            currentStatus = statusOptions.PushForward;
            altStatus = statusOptions.PushForward;
        }
        if (setMe2 == PushForward)
        {
            altStatus2 = statusOptions.PushForward;
        }
        if (setMe3 == PushForward)
        {
            altStatus3 = statusOptions.PushForward;
        } 
        if (setMe == PushBack)
        {
            currentStatus = statusOptions.PushBack;
            altStatus = statusOptions.PushBack;
        }
        if (setMe2 == PushBack)
        {
            altStatus2 = statusOptions.PushBack;
        }
        if (setMe3 == PushBack)
        {
            altStatus3 = statusOptions.PushBack;
        } 
        if (setMe == LeftBumper)
        {
            currentStatus = statusOptions.LeftBumper;
            altStatus = statusOptions.LeftBumper;
        }
        if (setMe2 == LeftBumper)
        {
            altStatus2 = statusOptions.LeftBumper;
        }
        if (setMe3 == LeftBumper)
        {
            altStatus3 = statusOptions.LeftBumper;
        } 
        if (setMe == RightBumper)
        {
            currentStatus = statusOptions.RightBumper;
            altStatus = statusOptions.RightBumper;
        }
        if (setMe2 == RightBumper)
        {
            altStatus2 = statusOptions.RightBumper;
        }
        if (setMe3 == RightBumper)
        {
            altStatus3 = statusOptions.RightBumper;
        }  
       
    }
    public void  applyEffects()
    {
        if (savePoint == true)
        {
            startGame.startG.spawnPoint = gameObject;
        }
        if (currentStatus == statusOptions.TheEnd)
        {
            //incrament score && load next scene - make scene Application.LoadLevel(nextLevelName);
            soundManager.m.Play(2);
        }
        if (currentStatus == statusOptions.Damaging)
        {
            //lose one life when moving onto
            soundManager.m.Play(5);
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
        if (currentStatus == statusOptions.LeftBumper)
        {
            gameObject.GetComponent<playerMove>().pushType = "leftBumper"; //down>right left>up right>down up>left
            gameObject.GetComponent<playerMove>().movePush(gameObject.GetComponent<playerMove>().pushType);
        } 
        if (currentStatus == statusOptions.RightBumper)
        {
            //pushes players back where they came
            gameObject.GetComponent<playerMove>().pushType = "rightBumper"; // down>left left>down right>up up>right
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
            renderer.material.SetColor("_Color", Inactive);               
        }
        if (currentStatus == statusOptions.Safe || currentStatus == statusOptions.TheEnd)
        {            
                //active safe green
            renderer.material.SetColor("_Color", Safe);
        }
        if (currentStatus == statusOptions.Damaging)
        {
            //special effect
            renderer.material.SetColor("_Color", Damaging);
        }
        
        if (currentStatus == statusOptions.PushForward)
        {
            //special effect
            renderer.material.SetColor("_Color", PushForward);
        }
        if (currentStatus == statusOptions.PushBack)
        {
            //special effect
            renderer.material.SetColor("_Color", PushBack);
        }
        if (currentStatus == statusOptions.ChangeSpeed)
        {
            //special effect
           //renderer.material.SetColor("_Color", ChangeSpeed);
        }
        if (currentStatus == statusOptions.Undeveloped)
        {

        }
        if (currentStatus == statusOptions.LeftBumper)
        {
            //special effect
            renderer.material.SetColor("_Color", LeftBumper);

        }
        if (currentStatus == statusOptions.RightBumper)
        {
            //special effect
            renderer.material.SetColor("_Color", RightBumper);
        }
    }
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Refreshing colors.");
            resetColor();
        }

        if (timerLength != null)
        {
            //stuff
        }

        //if (gameObject.GetComponent<playerMove>().isActive == true && buffer.Ok() == true)
       // {
            //applyEffects();
       // }
    }

   
}
