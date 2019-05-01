using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyHealth : MonoBehaviour
{
    public float hp;
    public CanDirectDamage fistChecker;
    public GameObject canvas;
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
        if (hp <= 0)
        {
            canvas.SetActive(true);
            Destroy(GetComponent<SpringJoint>());
            Invoke("Reload", 5);
        }
    }
    public void SubtractFromHPVel(Vector3 vel)
    {
        float w = (vel.x * vel.x) + (vel.y * vel.y) + (vel.z * vel.z);
        //Debug.Log("works?    " + w + "      can damage =  " + canDamage);
        hp -= w;
        //Debug.Log("      can damage =  " + canDamage);

        if (hp <= 0)
        {
            canvas.SetActive(true);
            Destroy(GetComponent<SpringJoint>());
            Invoke("Reload", 5);
        }

    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
