using UnityEngine;
using System.Collections;

public class drawLevel : MonoBehaviour
{
    public Texture2D layout;
    public Texture2D layoutAlt;
    public Texture2D layoutAlt2;
    public Texture2D layoutTime;
    public Texture2D camLayout;
    public GameObject pointSpawn;
    public GameObject camSpawn;
    public GameObject camMove;
    public Color dontInstantiate = new Color32(14, 0, 149, 255);
    public Color dontCamInstantiate = new Color32(255, 255, 255, 255);
    float camZ;

    playerMove[,] moveSets;
    camDir[,] camPoints;
    
    void Awake ()
    {
        moveSets = new playerMove[layout.width, layout.height];      
        instatiateLevel();
        linkLevel();
        camPoints = new camDir[camLayout.width, camLayout.height];
        camZ = camMove.GetComponent<camMove>().transform.position.z;
        instatiateCam();
    }

    void instatiateCam()
     {
         for (int curlineX = 0; curlineX < layout.width; curlineX++)
         {
             for (int curlineY = 0; curlineY < layout.height; curlineY++)
             {
                 Vector3 curPoint = new Vector3(curlineX, curlineY, 0);
                 Color curCol = camLayout.GetPixel(curlineX, curlineY);
                 if (curCol != dontCamInstantiate)
                 {
                     GameObject camPoint = Instantiate(camSpawn.gameObject, new Vector3(curlineX * 3, curlineY * 3, camMove.GetComponent<camMove>().camDist), transform.rotation) as GameObject;
                     camPoints[curlineX, curlineY] = camPoint.GetComponent<camDir>();

                     if (curCol == camMove.GetComponent<camMove>().sStart)
                     {
                         camMove.GetComponent<camMove>().transform.position = new Vector3 (camPoint.transform.position.x, camPoint.transform.position.y, camPoint.transform.position.y);
                    }
                     else if (curCol == camMove.GetComponent<camMove>().Left)
                     {
                         camPoint.GetComponent<camDir>().dirGo = camDir.directions.left;
                     }
                     else if (curCol == camMove.GetComponent<camMove>().Right)
                     {
                         camPoint.GetComponent<camDir>().dirGo = camDir.directions.right;
                     }
                     else if (curCol == camMove.GetComponent<camMove>().Down)
                     {
                         camPoint.GetComponent<camDir>().dirGo = camDir.directions.down;
                     }
                     else if (curCol == camMove.GetComponent<camMove>().Stop)
                     {
                         camPoint.GetComponent<camDir>().dirGo = camDir.directions.stop;
                     }

                 }
             }
         }

     }

    void linkLevel()
    {
        for (int curlineX = 0; curlineX < layout.width; curlineX++)
        {
            for (int curlineY = 0; curlineY < layout.height; curlineY++)
            {
                if (moveSets[curlineX, curlineY] != null)
                {
                    inception(curlineX, curlineY, -Vector2.up);
                    inception(curlineX, curlineY, Vector2.up);
                    inception(curlineX, curlineY, -Vector2.right);
                    inception(curlineX, curlineY, Vector2.right);                
                   
                }                      
            }
        }
    }

        void inception (int x, int y, Vector2 dir)
    {
        
        Vector2 target = new Vector2(x, y) + dir;

        if (inBounds((int)target.x, (int)target.y))
        {            
            if (moveSets[(int)target.x, (int)target.y] != null)
            {
                if (dir == -Vector2.up)
                {
                    moveSets[x, y].downTarget = moveSets[(int)target.x, (int)target.y].gameObject;
                }
                if (dir == Vector2.up)
                {
                    moveSets[x, y].upTarget = moveSets[(int)target.x, (int)target.y].gameObject;
                }
                if (dir == -Vector2.right)
                {
                    moveSets[x, y].leftTarget = moveSets[(int)target.x, (int)target.y].gameObject;
                }
                if (dir == Vector2.right)
                {
                    moveSets[x, y].rightTarget = moveSets[(int)target.x, (int)target.y].gameObject;
                }
                
            }
        }

        }

    bool inBounds(int x, int y)
    {
        if (x >= 0 && x < layout.width)
        {
            if (y >= 0 && y < layout.height)
            {
                return true;
            }
        }
        return false;
    }
    
    void instatiateLevel()
    {
        for (int curlineX = 0; curlineX < layout.width; curlineX++)
        {
            for (int curlineY = 0; curlineY < layout.height; curlineY++)
            {
                Color curPoint = layout.GetPixel(curlineX, curlineY);
                Color altPoint = layoutAlt.GetPixel(curlineX, curlineY);
                Color altPoint2 = layoutAlt2.GetPixel(curlineX, curlineY);
                Color timePoint = layoutTime.GetPixel(curlineX, curlineY);
                if (curPoint != dontInstantiate)
                {
                    GameObject transferPoint = Instantiate(pointSpawn.gameObject, new Vector3(curlineX, curlineY, 0) * 3, transform.rotation) as GameObject;
                    transferPoint.GetComponent<targetState>().setMe = curPoint;
                    transferPoint.GetComponent<targetState>().setMe2 = altPoint;
                    transferPoint.GetComponent<targetState>().setMe3 = altPoint2;
                    transferPoint.GetComponent<targetState>().timerColor = timePoint;
                    transferPoint.tag = "inActive";
                    moveSets[curlineX, curlineY] = transferPoint.GetComponent<playerMove>();

                }
            }
        }
    }
    
}