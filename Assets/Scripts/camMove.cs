using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

    public bool canMove = false;
    float camSpeed = 1;
    directions currentDir;
    enum directions { left, right, down, stop };
    public static camMove cam;
    public float camDist = -15;
    float camTranslate;
    public Color sStart = new Color32(147, 147, 147, 255);
    public Color Down = new Color32(237, 166, 28, 255);
    public Color Left = new Color32(238, 28, 36, 255);
    public Color Right = new Color32(237, 220, 28, 255);
    public Color Stop = new Color32(20, 20, 20, 255);

    void Start ()
    {
        cam = this;
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

    void OnCollisionEnter(Collision col)
    {

    }

    void speedUpdate ()
    {
        camTranslate = camSpeed * Time.deltaTime; 
    }

    void Update ()
    {
        if (canMove)
        {
            moveCam();
        }

        speedUpdate();
    }

}
