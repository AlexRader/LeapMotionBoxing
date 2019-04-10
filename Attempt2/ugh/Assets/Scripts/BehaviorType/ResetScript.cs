using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : DefaultType
{
    public GameObject interactable;
    public Vector3 pos;
    public Quaternion quat;
    float hp;
    // Use this for initialization
    void Start()
    {
        Transform savedTransfrom = interactable.transform;
        pos = savedTransfrom.position;
        quat = savedTransfrom.rotation;
        hp = interactable.GetComponent<DummyHealth>().hp;
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
        ResetObjectPos();
    }

    public void ResetObjectPos()
    {
        interactable.transform.position = pos;
        interactable.transform.rotation = quat;
        interactable.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
