using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
public class Movement : DefaultType
{
    public GameObject bullet, hand;
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
        SpawnBullet();
    }

    void SpawnBullet()
    {
        GameObject temp;
        InteractionHand hand1 = hand.GetComponent<InteractionHand>();
        float x = hand1._hand.Fingers[1].bones[3].Center.x;
        float y = hand1._hand.Fingers[1].bones[3].Center.y;
        float z = hand1._hand.Fingers[1].bones[3].Center.z;
        float xD = hand1._hand.Fingers[1].bones[3].Direction.x;
        float yD = hand1._hand.Fingers[1].bones[3].Direction.y;
        float zD = hand1._hand.Fingers[1].bones[3].Direction.z;
        temp = Instantiate(bullet, new Vector3(x, y, z), Quaternion.identity);
        temp.GetComponent<Rigidbody>().velocity = new Vector3(xD, yD, zD).normalized * 4;
    }
}