using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
    //The "player movement" script. Says if the player is "on" this object or not, and moves the player around to other objects. 
    //Calls targetState effects to happen on move, handles targetState move effects.
    //Handles respawn move as well.
    [HideInInspector]
    public GameObject upTarget;
    [HideInInspector]
    public GameObject downTarget;
    [HideInInspector]
    public GameObject leftTarget;
    [HideInInspector]
    public GameObject rightTarget;
    [HideInInspector]
    public bool _isActive;
    bool pushing;
    bool respawning;
    [HideInInspector]
    public string pushType = "none";
    Timer delay = new Timer();

    public bool isActive
    {
        get
        {
            return _isActive;
        }

        set
        {
            delay.setTimer(playerStats.Player.movePause); //SOLVED THE WEIRD JUMPING! AAHAAAAAA
            (gameObject.GetComponent("Halo") as Behaviour).enabled = value;
            if (value == true)
            {
                gameObject.tag = "Active";
            }
            else if (value == false)
            {
                gameObject.tag = "inActive";
            }
            _isActive = value;
        }
    }
    
    public bool canMove (GameObject target)
    {
        if (target != null)
        {
            if (target.GetComponent<targetState>().currentStatus != targetState.statusOptions.Inactive)
            {
                Debug.Log("Player can move.");
                return true;       
            }
            return false;
        }
            return false;
      

    }

    void Start()
    {
        delay.setTimer(playerStats.Player.respawnPause);
    }

    public void reSpawn()
    {
        if (respawning == false)
        {
            respawning = true;
            delay.setTimer(playerStats.Player.respawnPause);
        }        
        if (delay.Ok() == true && respawning == true)
        {
            if (startGame.startG.spawnPoint != this)
            {
                isActive = false;
            }      
            startGame.startG.spawnPoint.GetComponent<playerMove>().isActive = true;
            playerStats.Player.resetLife();
            delay.setTimer(playerStats.Player.respawnPause);
            respawning = false;
        }         
    }

    public void moveTo(GameObject target)
    {
        isActive = false;
        target.GetComponent<playerMove>().isActive = true;
        target.GetComponent<targetState>().applyEffects();
    }

    public void movePush(string type)
    {
        if (pushing == false)
        {
        pushing = true;
        Debug.Log(playerStats.Player.lastMove);
        delay.setTimer(playerStats.Player.movePause);
        }
        
        if (pushing && delay.Ok() == true)
        {
            if (playerStats.Player.lastMove == playerStats.moveDir.Left)
            {
                if (type == "back" && canMove(rightTarget) == true)
                {
                    moveTo(rightTarget);
                }
                if (type == "forward" && canMove(leftTarget) == true)
                {
                    moveTo(leftTarget);
                }
                pushing = false;
            }
            if (playerStats.Player.lastMove == playerStats.moveDir.Right)
            {
                if (type == "back" && canMove(leftTarget) == true)
                {
                    moveTo(leftTarget);
                }
                if (type == "forward" && canMove(rightTarget) == true)
                {
                    moveTo(rightTarget);
                }
                pushing = false;
            }
            if (playerStats.Player.lastMove == playerStats.moveDir.Up)
            {
                if (type == "back" && canMove(downTarget) == true)
                {
                    moveTo(downTarget);
                }
                if (type == "forward" && canMove(upTarget) == true)
                {
                    moveTo(upTarget);
                }
                pushing = false;
            }
            if (playerStats.Player.lastMove == playerStats.moveDir.Down)
            {
                if (type == "back" && canMove(upTarget) == true)
                {
                    moveTo(upTarget);
                }
                if (type == "forward" && canMove(downTarget) == true)
                {
                    moveTo(downTarget);
                } 
                pushing = false;
            }
        }
        
    }

	void Update () {
        if (pushing)
        {
            movePush(pushType);
        }
        if (isActive)
        {
            if (playerStats.Player.Lives <= 0)
            {
                playerStats.Player.isDead();
                reSpawn();
            }

            if (delay.Ok() == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove(leftTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Left;
                    moveTo(leftTarget);
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove(rightTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Right;
                    moveTo(rightTarget);
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow) && canMove(upTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Up; 
                    moveTo(upTarget);               
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove(downTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Down;
                    moveTo(downTarget);
                }
            }                       
        }      
	
	}
}
