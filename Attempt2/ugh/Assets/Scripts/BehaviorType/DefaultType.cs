using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultType : MonoBehaviour
{
    public float timer;
    public float timerMax;
    public virtual void Action()
    {
        return;
    }
    public virtual float GetTimer()
    {
        return timer;
    }
    public virtual void Update()
    {
        return;
    }
}
