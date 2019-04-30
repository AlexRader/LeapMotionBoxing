using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBehaviors : MonoBehaviour
{
    public List<GameObject> interactions;
    public List<GameObject> interactions1;
    public List<GameObject> interactions2;
    public List<GameObject> interactions3;
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
            for (int i = 0; i < interactions.Count; ++i)
            {
                if (interactions[i].activeInHierarchy)
                {
                    interactions[i].SetActive(false);
                    ++i;
                    i %= interactions.Count;

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
        x = x % interactions.Count;
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

    public void ChangeList()
    {
        for (int i = 0; i < interactions.Count; ++i)
        {
            interactions[i].SetActive(false);
        }
        interactions.Clear();
        currentBehavior = null;
        hold = false;
    }
    public void ChangeList1()
    {
        ChangeList();
        for (int i = 0; i < interactions1.Count; ++i)
        {
            interactions.Add(interactions1[i]);
        }
        currentBehavior = interactions[0];
        interactions[0].SetActive(true);
    }
    public void ChangeList2()
    {
        ChangeList();
        for (int i = 0; i < interactions2.Count; ++i)
        {
            interactions.Add(interactions2[i]);
        }
        currentBehavior = interactions[0];
        interactions[0].SetActive(true);
    }
    public void ChangeList3()
    {
        ChangeList();
        for (int i = 0; i < interactions3.Count; ++i)
        {
            interactions.Add(interactions3[i]);
        }
        currentBehavior = interactions[0];
        interactions[0].SetActive(true);
    }



}
