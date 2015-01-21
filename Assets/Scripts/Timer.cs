using UnityEngine;
using System.Collections;

public class Timer
{
    //Timer function to be used in other classes. Please do /not/ touch this.
    float timerstart = 0;
    float input = 0;
    public bool inuse = false;

    public void setTimer(float inpoot)
    {
        input = inpoot;
        timerstart = Time.time;
        inuse = true;
    }


    public bool Ok()
    {
        if (inuse == false)
        {
            return false;
        }
        else if ((Time.time - timerstart) >= input)
        {
            return true;
        }

        return false;
    }

    public void sleep()
    {
        inuse = false;

    }
    public float progress(float startTime, float moveSpeed)
    {
        return (Time.time - startTime) / moveSpeed;
    }
}