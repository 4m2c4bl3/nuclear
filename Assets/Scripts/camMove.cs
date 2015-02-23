using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

    public bool _Move = false;
    public float camSpeed = 1;
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
    public bool resetPlz = false;
    Timer pauseTimer = new Timer();
    void Start ()
    {
        cam = this;
        gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, camDist);
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
        if (transform.position.x == playerHere.transform.position.x)
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
            transform.position = new Vector3 (playerHere.transform.position.x, playerHere.transform.position.y, camDist);
        }
    }

    void camPos ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Active");
        if (gameObject.transform.position.x >= player.transform.position.x)
        {
            camSpeed = 4;
        }
        else if (gameObject.transform.position.x < player.transform.position.x - 4)
        {
            camSpeed = 10;
        }
        else if (gameObject.transform.position.x < player.transform.position.x)
        {
            camSpeed = 7;
        }

    }

    void outOfBounds()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Active");
        if (gameObject.transform.position.x >= player.transform.position.x + deathBuffer)
        {
            playerStats.Player.Lives = 0;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<camDir>().dirGo == camDir.directions.left)
        {
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
