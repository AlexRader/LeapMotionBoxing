using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour
{
    public float hp;
    public CanDirectDamage fistChecker;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SubtractFromHP(Vector3 vel, bool whichHand)
    {
        bool canDamage;
        if (whichHand)
            canDamage = fistChecker.getDamageL();
        else
            canDamage = fistChecker.getDamageR();
        float w = (vel.x * vel.x) + (vel.y * vel.y) + (vel.z * vel.z);
        //Debug.Log("works?    " + w + "      can damage =  " + canDamage);
        hp -= w;
        //Debug.Log("      can damage =  " + canDamage);
    }
}
