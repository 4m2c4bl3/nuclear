using UnityEngine;
using System.Collections;

public class drawLevel : MonoBehaviour
{
    public Texture2D layout;
    public Texture2D camLayout;
    public GameObject pointSpawn;
    public GameObject camSpawn;
    public GameObject camMove;
    public int intCamDir = 1; // 0 = up 1 = right 2 = down 3  = left
    public Color dontInstantiate = new Color32(14, 0, 149, 255);
    public Color dontCamInstantiate = new Color32(14, 0, 149, 255);

    playerMove[,] moveSets;
    camDirs[,] camPoints;
    
    void Awake ()
    {
        moveSets = new playerMove[layout.width, layout.height];      
        instatiateLevel();
        linkLevel();
        camPoints = new camDirs[camLayout.width, camLayout.height];        
    }

    void Start ()
    {
       instatiateCam();
       linkCam();
    }

    void linkCam()
    {
        for (int curlineX = 0; curlineX < layout.width; curlineX++)
        {
            for (int curlineY = 0; curlineY < layout.height; curlineY++)
            {
                if (camPoints[curlineX, curlineY] != null)
                {
                      Color curCol = camLayout.GetPixel(curlineX, curlineY);
                      if (curCol == camMove.GetComponent<camMove>().camStart)
                      {
                          if (intCamDir == 0)
                          {
                              camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX , curlineY + 1].gameObject;
                          }
                          if (intCamDir == 1)
                          {
                              camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX + 1, curlineY].gameObject;
                          }
                          if (intCamDir == 2)
                          {
                              camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX, curlineY - 1].gameObject;
                          }
                          if (intCamDir == 3)
                          {
                              camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX - 1, curlineY].gameObject;
                          }

                      }
                      if (curCol == camMove.GetComponent<camMove>().camEnd)
                      {

                      }
                      else if (curCol == camMove.GetComponent<camMove>().moveUp)
                      {
                          camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX, curlineY + 1].gameObject;
                          //camPoints[curlineX, curlineY].backTarget = camPoints[curlineX, curlineY - 1].gameObject;
                      }
                      else if (curCol == camMove.GetComponent<camMove>().moveRight)
                      {
                          camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX + 1, curlineY].gameObject;
                          //camPoints[curlineX, curlineY].backTarget = camPoints[curlineX - 1, curlineY].gameObject;
                      }
                      else if (curCol == camMove.GetComponent<camMove>().moveDown)
                      {
                          camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX, curlineY - 1].gameObject;
                          //camPoints[curlineX, curlineY].backTarget = camPoints[curlineX, curlineY + 1].gameObject;
                      }
                      else if (curCol == camMove.GetComponent<camMove>().moveLeft)
                      {
                          camPoints[curlineX, curlineY].forwardTarget = camPoints[curlineX - 1, curlineY].gameObject;
                          //camPoints[curlineX, curlineY].backTarget = camPoints[curlineX + 1, curlineY].gameObject;
                      }
                    
                }
            }
        }
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
                     GameObject camPoint = Instantiate(camSpawn.gameObject, new Vector3(curlineX, curlineY, -1) * 3, transform.rotation) as GameObject;
                     camPoints[curlineX, curlineY] = camPoint.GetComponent<camDirs>();
                     if (curCol == camMove.GetComponent<camMove>().camStart)
                     {
                         camMove.GetComponent<camMove>().transform.parent = camPoint.transform;

                         if (intCamDir == 0)
                         {
                             camPoint.tag = "camUp";
                         }
                         if (intCamDir == 1)
                         {
                             camPoint.tag = "camRight";
                         }
                         if (intCamDir == 2)
                         {
                             camPoint.tag = "camDown";
                         }
                         if (intCamDir == 3)
                         {
                             camPoint.tag = "camLeft";
                         }

                     }
                     else if (curCol == camMove.GetComponent<camMove>().moveUp)
                     {
                         camPoint.tag = "camUp";
                     }
                     else if (curCol == camMove.GetComponent<camMove>().moveRight)
                     {
                         camPoint.tag = "camRight";
                     }
                     else if (curCol == camMove.GetComponent<camMove>().moveDown)
                     {
                         camPoint.tag = "camDown";
                     }
                     else if (curCol == camMove.GetComponent<camMove>().moveLeft)
                     {
                         camPoint.tag = "camLeft";
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
                if (curPoint != dontInstantiate)
                {
                    GameObject transferPoint = Instantiate(pointSpawn.gameObject, new Vector3(curlineX, curlineY, 0) * 3, transform.rotation) as GameObject;
                    transferPoint.GetComponent<targetState>().setMe = curPoint;
                    transferPoint.tag = "inActive";
                    moveSets[curlineX, curlineY] = transferPoint.GetComponent<playerMove>();

                }
            }
        }
    }
    
}