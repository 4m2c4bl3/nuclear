using UnityEngine;
using System.Collections;

public class targetState : MonoBehaviour {
    //Tells the target what effects it should do.
   public int Status = 1;
   Timer buffer = new Timer();
   public Color effect0;
   public Color effect1;

    void Start ()
   {
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
