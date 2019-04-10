using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBehaviors : MonoBehaviour
{
    public GameObject[] interactions;
    bool hold;
    public GameObject currentBehavior;
    float timer;
    float timerMax = 0.1f;
    public int x;
	// Use this for initialization
	void Start ()
    {
        x = 0;
        hold = false;
        currentBehavior = interactions[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hold)
            return;
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            for (int i = 0; i < interactions.Length; ++i)
            {
                if (interactions[i].activeInHierarchy)
                {
                    interactions[i].SetActive(false);
                    ++i;
                    i %= interactions.Length;
                    interactions[i].SetActive(true);
                    currentBehavior = interactions[i];
                    x = i;
                    timer = 0;
                    break;
                }
            }  
        }
	}

    public void ActivationStart()
    {
        x += 1;
        x = x % interactions.Length;
        currentBehavior = interactions[x];
        DefaultType temp = currentBehavior.GetComponent<DefaultType>();

        if (temp.GetTimer() <= 0)
        {
            temp.Action();
        }
        hold = true;
    }
    public void ActivationEnd()
    {
        DefaultType temp = currentBehavior.GetComponent<DefaultType>();
        temp.timer = 0;
        hold = false;
    }

    void ActivateCorrectObject()
    {
    }


}
