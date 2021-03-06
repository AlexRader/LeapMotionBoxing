﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction
{
    
    public class MyHandTest : MonoBehaviour
    {
        public Hand handRef;
        public GameObject myHand, handActive;
        public float distance;
        public float timer = 1.0f;

        public bool firstList;

        public GameObject[] checkers;
        testBehaviors reference;
        // Use this for initialization
        void Start()
        {
            firstList = false;
            distance = 0;
            handRef = myHand.GetComponent<InteractionHand>()._hand;
            reference = transform.GetChild(0).gameObject.GetComponent<testBehaviors>();
            //StartCoroutine(testing());
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(handRef);
            if (handActive.activeSelf)//handRef.Fingers[1].Type != 0 && handRef.IsLeft)
            {
                distance = Vector3.Distance(handRef.Fingers[1].bones[3].Center.ToVector3(),
                                handRef.Fingers[1].bones[0].Center.ToVector3());
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    StartCoroutine(testing());
                    timer = 1;
                }
            }
            //Debug.Log(handActive.activeSelf);

            if (firstList)
            {

            }
        }

        public IEnumerator testing()
        {
            yield return new WaitForSeconds(1.0f);
            //if (myHand != null)
            //{
            if (handActive.activeSelf && handActive.GetComponent<CapsuleHand>().Handedness == 0)
            //if (myHand.GetComponent<InteractionHand>()._hand.IsLeft)
                handRef = myHand.GetComponent<InteractionHand>()._hand;
            //}
            //myHand = GameObject.Find("Interaction Hand (Left)");
        }

        public void TrackFirstList()
        {
            Debug.Log("systemStuff");
            reference.enabled = true;
            reference.ChangeList1();
            TurnOff();
        }
        public void TrackSecondList()
        {
            Debug.Log("abilitiesMovement");
            reference.enabled = true;
            reference.ChangeList2();
            TurnOff();
        }
        public void TrackThirdList()
        {
            Debug.Log("abilitiesAttack");
            reference.enabled = true;
            reference.ChangeList3();
            TurnOff();
        }

        void TurnOff()
        {
            ExtendedFingerDetector[] checks;
            for (int i = 0; i < checkers.Length; ++i)
            {
                checks = checkers[i].GetComponents<ExtendedFingerDetector>();
                foreach (ExtendedFingerDetector x in checks)
                {
                    x.enabled = false;
                }
            }
            firstList = !firstList;
        }
        public void TurnOn()
        {
            ExtendedFingerDetector[] checks;
            for (int i = 0; i < checkers.Length; ++i)
            {
                checks = checkers[i].GetComponents<ExtendedFingerDetector>();
                foreach (ExtendedFingerDetector x in checks)
                {
                    x.enabled = true;
                }
            }
            firstList = !firstList;
        }

    }
}
