//using Oculus.Interaction;
using TMPro;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Manipulation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;

public class WatchForReleased : MonoBehaviour
{
    public UxrGrabbableObject grabbableObject;
    MotionVectorCalculator motionVectorCalculator;
    EffectsOnReleased effectsOnReleased;
    ObjectTracker objectTracker;
    DrawAxis3D drawAxis3D;
    public TextMeshPro heightAboveOriginText;
    public TextMeshPro launchSpeedText;
    public TextMeshPro launchAngleText;
    public TextMeshPro heightBelowOriginText;
    public TextMeshPro horizontalDistanceText;

    bool waitingCollision;
    private float launchSpeed;
    private float launchAngle;

    private void OnEnable()
    {
        UxrGrabManager.Instance.ObjectReleased += UxrGrabManager_ObjectReleased;
        UxrGrabManager.Instance.ObjectReleasing += UxrGrabManager_ObjectReleasing;
    }

    private void OnDisable()
    {
        UxrGrabManager.Instance.ObjectReleased -= UxrGrabManager_ObjectReleased;
        UxrGrabManager.Instance.ObjectReleasing -= UxrGrabManager_ObjectReleasing;
    }

    private void UxrGrabManager_ObjectReleased(object sender, UxrManipulationEventArgs e)
    {
        drawAxis3D.HideLine();
        PhysicsTextHideAll();
        effectsOnReleased.StartTrail();
        motionVectorCalculator.ApplyMotionToTransform();
        objectTracker.StartTracking();

        waitingCollision = true;
    }
    private void UxrGrabManager_ObjectReleasing(object sender, UxrManipulationEventArgs e)
    {
        motionVectorCalculator.SetVelocity(UxrGrabManager.Instance.GetGrabbedObjectVelocity(grabbableObject)*1.5f, UxrGrabManager.Instance.GetGrabbedObjectAngularVelocity(grabbableObject)/20.0f);
    }

    void Start()
    {
        motionVectorCalculator = GetComponent<MotionVectorCalculator>();

        effectsOnReleased = GetComponent<EffectsOnReleased>();
        objectTracker = GetComponent <ObjectTracker>();
        drawAxis3D = GetComponent<DrawAxis3D>();

        waitingCollision = false;
        PhysicsText.InitText(heightAboveOriginText, "0.00", false, 72);
        PhysicsText.InitText(launchSpeedText, "0.00", false, 72);
        PhysicsText.InitText(launchAngleText, "0.00", false, 72);
        PhysicsText.InitText(heightBelowOriginText, "0.00", false, 72);
        PhysicsText.InitText(horizontalDistanceText, "0.00", false, 72);
        launchSpeed = 0;
        launchAngle = 0;
    }

    void LateUpdate()
    {

        bool thumb = UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button2);
        if (thumb)
            Relaunch();
    }

    public void Relaunch()
    {
        transform.position = objectTracker.initialPosition;
        drawAxis3D.HideLine();
        PhysicsTextHideAll();
        effectsOnReleased.StartTrail();
        motionVectorCalculator.ReapplyMotionToTransform();
        objectTracker.StartTracking();

        waitingCollision = true;
        Debug.Log("Waiting for COLLISION");
    }

    public void PhysicsTextHideAll()
    {
        PhysicsText.TextShow(heightAboveOriginText, false);
        PhysicsText.TextShow(launchSpeedText, false);
        PhysicsText.TextShow(launchAngleText, false);
        PhysicsText.TextShow(horizontalDistanceText, false);
        PhysicsText.TextShow(heightBelowOriginText, false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (waitingCollision)
        {
            objectTracker.StopTracking();
            effectsOnReleased.StopTrail();
            drawAxis3D.DrawMainAxis();
            float projectileHeightAboveOrigin = objectTracker.highestPosition.y - objectTracker.initialPosition.y;
            Vector3 textPosition = objectTracker.highestPosition - new Vector3(0, projectileHeightAboveOrigin / 2, 0);
            PhysicsText.TextSet(heightAboveOriginText, projectileHeightAboveOrigin.ToString("0.00") + "m");
            Vector3 finalPositionAdjusted = objectTracker.finalPosition;
            finalPositionAdjusted.y = objectTracker.initialPosition.y;
            Quaternion turn = Quaternion.Euler(Vector3.Cross(Vector3.up, objectTracker.initialPosition - finalPositionAdjusted));
            

            PhysicsText.TextRotate(heightAboveOriginText, turn);
            PhysicsText.TextPosition(heightAboveOriginText, textPosition);
            PhysicsText.TextShow(heightAboveOriginText, true);

            launchSpeed = motionVectorCalculator.GetSpeed();
            PhysicsText.TextSet(launchSpeedText, launchSpeed.ToString("0.00") + " m/s");
            PhysicsText.TextRotate(launchSpeedText, turn);
            PhysicsText.TextPosition(launchSpeedText, objectTracker.initialPosition);
            PhysicsText.TextShow(launchSpeedText, true);

            launchAngle = motionVectorCalculator.GetAngle();
            PhysicsText.TextSet(launchAngleText, launchAngle.ToString("0.00") + " degrees");
            PhysicsText.TextRotate(launchAngleText, turn);
            PhysicsText.TextPosition(launchAngleText, objectTracker.initialPosition - new Vector3(0,0.15f,0));
            PhysicsText.TextShow(launchAngleText, true);

            float horizontalDistance = drawAxis3D.GetHorizontalDistance();
            PhysicsText.TextSet(horizontalDistanceText, horizontalDistance.ToString("0.00") + "m");
            PhysicsText.TextRotate(horizontalDistanceText, turn);
            PhysicsText.TextPosition(horizontalDistanceText, drawAxis3D.GetHorizontalFarPos());
            PhysicsText.TextShow(horizontalDistanceText, true);

            float heightBelow = drawAxis3D.GetVerticalDistanceDown();
            PhysicsText.TextSet(heightBelowOriginText, heightBelow.ToString("0.00") + "m");
            PhysicsText.TextRotate(heightBelowOriginText, turn);
            PhysicsText.TextPosition(heightBelowOriginText, drawAxis3D.GetVerticalDownPos());
            PhysicsText.TextShow(heightBelowOriginText, true);

            waitingCollision = false;
            Debug.Log("Found COLLISION");
        }
    }
}
