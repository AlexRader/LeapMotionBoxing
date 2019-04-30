using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
public class ReturnToDefault : DefaultType
{
    public testBehaviors behaviorRef;
    public MyHandTest myHandTest;
    // Use this for initialization
    void Start()
    {

    }
    public override void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public override void Action()
    {
        timer = timerMax;
        myHandTest.TurnOn();
        behaviorRef.ChangeList();
        behaviorRef.enabled = false;
    }

}
