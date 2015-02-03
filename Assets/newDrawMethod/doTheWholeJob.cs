using UnityEngine;
using System.Collections;

public class doTheWholeJob : MonoBehaviour
{
    public Texture2D layout;
    public GameObject pointSpawn;
    public Color dontInstantiate = new Color32(14, 0, 149, 255);

    playerMove[,] moveSets;
    
    void Start()
    {
        moveSets = new playerMove[layout.width, layout.height]; 
        drawLevel();
        linkLevel();        
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
    
    void drawLevel()
    {
        for (int curlineX = 0; curlineX < layout.width; curlineX++)
        {
            for (int curlineY = 0; curlineY < layout.height; curlineY++)
            {
                Color curPoint = layout.GetPixel(curlineX, curlineY);
                if (curPoint != dontInstantiate)
                {
                    GameObject transferPoint = Instantiate(pointSpawn.gameObject, new Vector3(curlineX, curlineY, 0) * 2, transform.rotation) as GameObject;
                    transferPoint.GetComponent<targetState>().setMe = curPoint;
                    moveSets[curlineX, curlineY] = transferPoint.GetComponent<playerMove>();

                }
            }
        }
    }
    
}