using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBuck : DefaultType
{
    public GameObject interactable;
    public Material danMat;
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
        ChangeFace();
    }

    public void ChangeFace()
    {
        interactable.GetComponent<MeshRenderer>().material = danMat;
    }
}
