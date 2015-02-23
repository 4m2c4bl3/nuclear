using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {
    [HideInInspector]
    public bool _Move = false;
    public float camSpeed = 1;
    [HideInInspector]
    public directions currentDir;
    public enum directions { right, left, down, stop };
    public static camMove cam;
    public float camDist = -15;
    float camTranslate;
    [HideInInspector]
    public Color sStart = new Color32(147, 147, 147, 255);
    [HideInInspector]
    public Color Down = new Color32(237, 166, 28, 255);
    [HideInInspector]
    public Color Left = new Color32(238, 28, 36, 255);
    [HideInInspector]
    public Color Right = new Color32(237, 220, 28, 255);
    [HideInInspector]
    public Color Stop = new Color32(20, 20, 20, 255);
    Vector3 playerpos;
    public float deathBuffer = 3;
    float camOffset = 4;
    public float slow = 3;
    public float med = 7;
    public float fast = 10;
    [HideInInspector]
    public bool resetPlz = false;
    Timer pauseTimer = new Timer();
    void Start ()
    {
        cam = this;
        gameObject.transform.position = new Vector3 (transform.position.x + camOffset, transform.position.y, camDist);
    }

    void moveCam ()
    {
        if (currentDir == directions.left)
        {
            transform.Translate(Vector3.left * camTranslate);
        }
        else if (currentDir == directions.right)
        {
            transform.Translate(Vector3.right * camTranslate);
        }
        else if (currentDir == directions.down)
        {
            transform.Translate(Vector3.down * camTranslate);
        }
    }

    public void canMove()
    {
        if (pauseTimer.inuse == false)
        {
            pauseTimer.setTimer(playerStats.Player.respawnPause);
        }
        if (pauseTimer.inuse == true)
        {
            if (pauseTimer.Ok())
            {
                _Move = true;
                pauseTimer.sleep();
            }
        }
    }

    void resetCam ()
    {
        GameObject playerHere = GameObject.FindGameObjectWithTag("Active");
        

        if (currentDir == directions.down && transform.position.y == playerHere.transform.position.y)
        {
            if (pauseTimer.inuse == false)
            {
                pauseTimer.setTimer(playerStats.Player.respawnPause);
            }
            resetPlz = false;
        }
        else if (transform.position.x - camOffset == playerHere.transform.position.x)
        {
            if (pauseTimer.inuse == false)
            {
                pauseTimer.setTimer(playerStats.Player.respawnPause);
            }
            resetPlz = false;
        }

        else
        {      
            _Move = false;
            transform.position = new Vector3(playerHere.transform.position.x + camOffset, playerHere.transform.position.y, camDist);
        }
    }

    void camPos ()
    {
        if (currentDir == directions.right)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Active");
            if (gameObject.transform.position.x - camOffset >= player.transform.position.x)
            {
                camSpeed = slow;
            }
            else if (gameObject.transform.position.x - camOffset < player.transform.position.x - 4)
            {
                camSpeed = fast;
            }
            else if (gameObject.transform.position.x - camOffset < player.transform.position.x)
            {
                camSpeed = med;
            }

        }
        if (currentDir == directions.left)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Active");
            if (gameObject.transform.position.x - camOffset < player.transform.position.x)
            {
                camSpeed = slow;
            }
            else if (gameObject.transform.position.x - camOffset >= player.transform.position.x - 4)
            {
                camSpeed = fast;
            }
            else if (gameObject.transform.position.x - camOffset >= player.transform.position.x)
            {
                camSpeed = med;
            }

        }

        if (currentDir == directions.down)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Active");
            if (gameObject.transform.position.y < player.transform.position.y)
            {
                camSpeed = slow;
            }
            else if (gameObject.transform.position.y >= player.transform.position.y - 4)
            {
                camSpeed = med;
            }
            else if (gameObject.transform.position.y >= player.transform.position.x)
            {
                camSpeed = fast;
            }

        }


    }

    void outOfBounds()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Active");
        if (currentDir == directions.right && gameObject.transform.position.x - camOffset >= player.transform.position.x + deathBuffer)
        {
            playerStats.Player.Lives = 0;
        }

        if (currentDir == directions.left && gameObject.transform.position.x - camOffset <= player.transform.position.x + deathBuffer)
        {
            playerStats.Player.Lives = 0;
        }

        if (currentDir == directions.down && gameObject.transform.position.y <= player.transform.position.y - deathBuffer)
        {
            playerStats.Player.Lives = 0;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<camDir>().dirGo == camDir.directions.left)
        {
            transform.RotateAround(transform.position, transform.up, 0f);
            currentDir = directions.left;
        }
        if (col.gameObject.GetComponent<camDir>().dirGo == camDir.directions.right)
        {
            currentDir = directions.right;
        }
        if (col.gameObject.GetComponent<camDir>().dirGo == camDir.directions.down)
        {
            currentDir = directions.down;
        }
        if (col.gameObject.GetComponent<camDir>().dirGo == camDir.directions.stop)
        {
            _Move = false;
        }
    }

    void speedUpdate ()
    {
        camTranslate = camSpeed * Time.deltaTime; 
    }

    void Update ()
    {
        if (_Move)
        {
            moveCam();
        }
        if (resetPlz == true)
        {
            resetCam();
        }
        if (pauseTimer.inuse)
        {
            if (pauseTimer.Ok())
            {
                _Move = true;
                pauseTimer.sleep();
            }
        }
        camPos();
        speedUpdate();
        outOfBounds();

    }

}
