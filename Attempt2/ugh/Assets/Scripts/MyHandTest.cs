using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction
{
    public class MyHandTest : MonoBehaviour
    {
        public Hand handRef;
        public GameObject myHand;
        public float distance;
        public float timer = 1.0f;
        // Use this for initialization
        void Start()
        {
            distance = 0;
            handRef = myHand.GetComponent<InteractionHand>()._hand;
            //StartCoroutine(testing());
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(handRef);
            Debug.Log(handRef.Fingers[1].Type);
            if (handRef.Fingers[1].Type != 0 && handRef.IsLeft)
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
            Debug.Log(myHand.activeSelf);
        }

        public IEnumerator testing()
        {
            yield return new WaitForSeconds(1.0f);
            if (myHand != null)
            {
                if (myHand.GetComponent<InteractionHand>()._hand.IsLeft)
                    handRef = myHand.GetComponent<InteractionHand>()._hand;
            }
            //myHand = GameObject.Find("Interaction Hand (Left)");
        }

    }
}
