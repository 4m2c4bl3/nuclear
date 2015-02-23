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
    bool _isActive;
    bool pushing;
    bool respawning;
    [HideInInspector]
    public string pushType = "none";
    Timer delay = new Timer();
    public GameObject rotater;
    GameObject Atom;

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
                return true;       
            }
            return false;
        }
            return false; 
    }

    void Start()
    {        
        delay.setTimer(playerStats.Player.respawnPause);
        if (isActive)
        {
            if (GameObject.FindGameObjectWithTag("Atom") == null)
            {
                Vector3 behere = new Vector3(0, 0, 0);
                Atom = Instantiate(rotater.gameObject, behere, transform.rotation) as GameObject;
                Atom.transform.parent = gameObject.transform;
            }
        }        
    }

    public void reSpawn()
    {
        if (respawning == false)
        {
            respawning = true;
            soundManager.m.Play(3);
            delay.setTimer(playerStats.Player.respawnPause);
        }        
        if (delay.Ok() == true && respawning == true)
        {
            if (startGame.startG.spawnPoint != this)
            {
                isActive = false;
            }
            startGame.startG.spawnPoint.GetComponent<playerMove>().isActive = true;
            camMove.cam.resetPlz = true;
            Atom.transform.parent = startGame.startG.spawnPoint.transform;
            playerStats.Player.resetLife();
            delay.setTimer(playerStats.Player.respawnPause);
            respawning = false;
        }         
    }

    void moveTo(GameObject target)
    {
        Atom.transform.parent = target.transform;
        isActive = false;
        target.GetComponent<playerMove>().isActive = true;
        target.GetComponent<targetState>().applyEffects();
    }
    public void lastMoveSet(GameObject target)
    {
        if (target == upTarget)
        {
            playerStats.Player.lastMove = playerStats.moveDir.Up;
        }
        else if (target == downTarget)
        {
            playerStats.Player.lastMove = playerStats.moveDir.Down;
        }
        else if (target == leftTarget)
        {
            playerStats.Player.lastMove = playerStats.moveDir.Left;
        }
        else if (target == rightTarget)
        {
            playerStats.Player.lastMove = playerStats.moveDir.Right;
        }
    }

    public void movePush(string type)
    {
        if (pushing == false)
        {
        pushing = true;
        delay.setTimer(playerStats.Player.movePause);
        }
        
        if (pushing && delay.Ok() == true)
        {
            if (playerStats.Player.lastMove == playerStats.moveDir.Left)
            {
                if (type == "leftBumper" && canMove(upTarget) == true)
                {
                    lastMoveSet(upTarget);
                    moveTo(upTarget);
                    soundManager.m.Play(7);
                } 
                if (type == "rightBumper" && canMove(downTarget) == true)
                {
                    lastMoveSet(downTarget);
                    moveTo(downTarget);
                    soundManager.m.Play(7);
                }
                if (type == "back" && canMove(rightTarget) == true)
                {
                    lastMoveSet(rightTarget);
                    moveTo(rightTarget);
                    soundManager.m.Play(7);
                }
                if (type == "forward" && canMove(leftTarget) == true)
                {
                    lastMoveSet(leftTarget);
                    moveTo(leftTarget);
                    soundManager.m.Play(6);
                }
                pushing = false;
            }
            else if (playerStats.Player.lastMove == playerStats.moveDir.Right)
            {
                if (type == "leftBumper" && canMove(downTarget) == true)
                {
                    lastMoveSet(downTarget);
                    moveTo(downTarget);
                    soundManager.m.Play(7);
                }
                if (type == "rightBumper" && canMove(upTarget) == true)
                {
                    lastMoveSet(upTarget);
                    moveTo(upTarget);
                    soundManager.m.Play(7);
                }
                if (type == "back" && canMove(leftTarget) == true)
                {
                    lastMoveSet(leftTarget);
                    moveTo(leftTarget);
                    soundManager.m.Play(7);
                }
                if (type == "forward" && canMove(rightTarget) == true)
                {
                    lastMoveSet(rightTarget);
                    moveTo(rightTarget);
                    soundManager.m.Play(6);
                }
                pushing = false;
            }
            else if (playerStats.Player.lastMove == playerStats.moveDir.Up)
            {
                if (type == "leftBumper" && canMove(leftTarget) == true)
                {
                    lastMoveSet(leftTarget);
                    moveTo(leftTarget);
                    soundManager.m.Play(7);
                }
                if (type == "rightBumper" && canMove(rightTarget) == true)
                {
                    lastMoveSet(rightTarget);
                    moveTo(rightTarget);
                    soundManager.m.Play(7);
                }
                if (type == "back" && canMove(downTarget) == true)
                {
                    lastMoveSet(downTarget);
                    moveTo(downTarget);
                    soundManager.m.Play(7);
                }
                if (type == "forward" && canMove(upTarget) == true)
                {
                    lastMoveSet(upTarget);
                    moveTo(upTarget);
                    soundManager.m.Play(6);
                }
                pushing = false;
            }
            else if (playerStats.Player.lastMove == playerStats.moveDir.Down)
            {
                if (type == "leftBumper" && canMove(rightTarget) == true)
                {
                    lastMoveSet(rightTarget);
                    moveTo(rightTarget);
                    soundManager.m.Play(7);
                }
                if (type == "rightBumper" && canMove(leftTarget) == true)
                {
                    lastMoveSet(leftTarget);
                    moveTo(leftTarget);
                    soundManager.m.Play(7);
                }
                if (type == "back" && canMove(upTarget) == true)
                {
                    lastMoveSet(upTarget);
                    moveTo(upTarget);
                    soundManager.m.Play(7);
                }
                if (type == "forward" && canMove(downTarget) == true)
                {
                    lastMoveSet(downTarget);
                    moveTo(downTarget);
                    soundManager.m.Play(6);
                } 
                pushing = false;
            }
        }
        
    }

    void Update()
    {
        if (pushing)
        {
            movePush(pushType);
        }
        if (isActive)
        {
            if (GameObject.FindGameObjectWithTag("Atom") != null)
            {
                Atom = GameObject.FindGameObjectWithTag("Atom");
            }
            if (playerStats.Player.Lives <= 0)
            {
                playerStats.Player.isDead();
                reSpawn();
            }

            if (delay.Ok() == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove(leftTarget) == true)
                {
                    lastMoveSet(leftTarget);
                    moveTo(leftTarget);
                    soundManager.m.Play(4);
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow) && canMove(rightTarget) == true)
                {
                    lastMoveSet(rightTarget);
                    moveTo(rightTarget);
                    soundManager.m.Play(4);
                }

                else if (Input.GetKeyDown(KeyCode.UpArrow) && canMove(upTarget) == true)
                {
                    lastMoveSet(upTarget);
                    moveTo(upTarget);
                    soundManager.m.Play(4);
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow) && canMove(downTarget) == true)
                {
                    lastMoveSet(downTarget);
                    moveTo(downTarget);
                    soundManager.m.Play(4);
                }
            }                       
        }      
	
	}
}
