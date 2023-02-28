using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform transformForForward;
    public float walkSpeed = 20.0f;
    public float rotateSpeed = 80.0f;
    public float xThreshold = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 v2 = Vector2.zero;//OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        float y = transform.position.y;
        if (v2.x > xThreshold || v2.x < -xThreshold)
        {
            transform.Translate((transformForForward.forward * v2.y * walkSpeed * Time.deltaTime));
            transform.Translate((transformForForward.right * v2.x * walkSpeed * Time.deltaTime));
            transform.Translate(new Vector3(0, y - transform.position.y, 0));
        }
        float v1 = 0;//OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        transform.Translate(new Vector3(0, 0 + (v1 * walkSpeed * Time.deltaTime), 0));
        v1 = 0;// OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        transform.Translate(new Vector3(0, 0 - (v1 * walkSpeed * Time.deltaTime), 0));

        //v2 = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        //transformForForward.Rotate(new Vector3(0, v2.x * rotateSpeed * Time.deltaTime, 0), Space.Self);

    }
}
