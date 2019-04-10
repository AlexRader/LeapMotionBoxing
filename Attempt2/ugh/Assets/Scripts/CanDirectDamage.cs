using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDirectDamage : MonoBehaviour
{
    bool canDamageL, canDamageR;
    // Use this for initialization
    void Start ()
    {
        canDamageL = false;
        canDamageR = false;
	}

    public void setDamageL()
    {
        //Debug.Log("meep");
        canDamageL = !canDamageL;
    }
    public bool getDamageL()
    {
        //Debug.Log("meep");
        return canDamageL;
    }
    public void setDamageR()
    {
        //Debug.Log("meep");
        canDamageR = !canDamageR;
    }
    public bool getDamageR()
    {
        //Debug.Log("meep");
        return canDamageR;
    }
}
