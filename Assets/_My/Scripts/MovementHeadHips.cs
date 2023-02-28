using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using AvatarController;

public class MovementHeadHips : MonoBehaviour
{
    public Transform head;
    public Transform hips;
    public float limit;
    Vector3 headRotation;
    Vector3 hipsRotation;

    void Start()
    {
        
    }

    void Update()
    {
       //if(head != null && hips != null)
       {
            headRotation = head.eulerAngles;
            hipsRotation = hips.eulerAngles;

            //hack to stop euler angles from wrapping 0-360
            if (headRotation.y > 180)
                headRotation.y -= 360;
            if (hipsRotation.y > 180)
                hipsRotation.y -= 360;

            if (headRotation.y + limit < hipsRotation.y)
                hips.eulerAngles = new Vector3(hips.eulerAngles.x, headRotation.y + limit, hips.eulerAngles.z);
            if (headRotation.y - limit > hipsRotation.y)
                hips.eulerAngles = new Vector3(hips.eulerAngles.x, headRotation.y - limit, hips.eulerAngles.z);

        }
    }
}
