using System.Collections;
using System.Collections.Generic;
using UltimateXR.Manipulation;
using UnityEngine;
using UnityEngine.XR;

public class MotionVectorCalculator : MonoBehaviour
{
    
    Rigidbody rigidbodyToApplyForce;
    public float strengthMultiplyer = 1.0f;
    private Vector3 lastLaunchVelocity;
    private Vector3 lastAngularVelocity;
    private float speed;
    private float angle;
    private UxrGrabbableObject grabbableObject;
    private Vector3 velocity;
    private Vector3 angularVelocity;
    void Awake()
    {
        rigidbodyToApplyForce = GetComponent<Rigidbody>();
        speed = 0;

    }
    public void SetVelocity(Vector3 v, Vector3 a)
    {
        velocity = v;
        angularVelocity = a;
    }
    public void ApplyMotionToTransform()
    {
        rigidbodyToApplyForce.isKinematic = false;
        rigidbodyToApplyForce.velocity = velocity;//UxrGrabManager.Instance.GetGrabbedObjectVelocity(grabbableObject);//Vector3.zero;//OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand) * strengthMultiplyer;
        rigidbodyToApplyForce.angularVelocity = angularVelocity;// UxrGrabManager.Instance.GetGrabbedObjectAngularVelocity(grabbableObject);//Vector3.zero;//OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RHand);

        lastLaunchVelocity = velocity;
        lastAngularVelocity = angularVelocity;

        Vector3 direction = lastLaunchVelocity.normalized; // Example direction vector
        Vector3 directionProjection = Vector3.ProjectOnPlane(direction, Vector3.up); // Project direction onto the horizontal plane
        angle = Vector3.Angle(direction, directionProjection);
        speed = rigidbodyToApplyForce.velocity.magnitude;
    }
    public void ReapplyMotionToTransform()
    {
        rigidbodyToApplyForce.velocity = lastLaunchVelocity;
        rigidbodyToApplyForce.angularVelocity = lastAngularVelocity;

        Vector3 direction = lastLaunchVelocity.normalized; // Example direction vector
        Vector3 directionProjection = Vector3.ProjectOnPlane(direction, Vector3.up); // Project direction onto the horizontal plane
        angle = Vector3.Angle(direction, directionProjection);
        speed = rigidbodyToApplyForce.velocity.magnitude;
    }

    public float GetSpeed()
    {
        return speed;
    }
    public float GetAngle()
    {
        return angle;
    }
}
