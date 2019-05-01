using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("SubtractFromHPVel", GetComponent<Rigidbody>().velocity);
        }
        Destroy(gameObject);
    }
}
