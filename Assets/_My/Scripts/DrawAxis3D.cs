using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawAxis3D : MonoBehaviour
{
    ObjectTracker objectTracker;
    public GameObject lineX;
    public GameObject lineY;
    public GameObject objectToFollow;
    public LineRenderer lineRendererX;
    public LineRenderer lineRendererY;
    Vector3 startX = Vector3.zero;
    Vector3 midX = Vector3.zero;
    Vector3 endX = Vector3.zero;
    private float objectYnow;
    private float objectYlast;
    private Vector3 highPoint;
    private bool highPointFound;
    private bool startTracking;
    int loopCount;
    // Start is called before the first frame update
    void Start()
    {
        objectTracker = GetComponent<ObjectTracker>();

        HideLine();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawMainAxis()
    {
        SetStartX();
        SetMidX();
        SetEndX();
        ShowLine();
    }
    public void SetStartX()
    {
        startX = objectTracker.initialPosition;
        lineRendererX.SetPosition(0, startX);
    }
    public void SetMidX()
    {
        midX = objectTracker.finalPosition;
        midX.y = startX.y;
        lineRendererX.SetPosition(1, midX);
    }
    public void SetEndX()
    {
        endX = objectTracker.finalPosition;
        lineRendererX.SetPosition(2, endX);
        lineRendererY.SetPosition(0, objectTracker.highestPosition);
        Vector3 vTmp = Vector3.zero;
        vTmp = objectTracker.highestPosition;
        vTmp.y = startX.y;
        lineRendererY.SetPosition(1, vTmp);
    }
    public void ShowLine()
    {
        lineX.SetActive(true);
        lineY.SetActive(true);
        Debug.Log("x 0 = " + lineRendererX.GetPosition(0).ToString());
        Debug.Log("x 1 = " + lineRendererX.GetPosition(1).ToString());
        Debug.Log("x 2 = " + lineRendererX.GetPosition(2).ToString());
        Debug.Log("y 0 = " + lineRendererY.GetPosition(0).ToString());
        Debug.Log("y 1 = " + lineRendererY.GetPosition(1).ToString());

    }
    public void HideLine()
    {
        lineX.SetActive(false);
        lineY.SetActive(false);
    }

    public float GetHorizontalDistance()
    {
        return (lineRendererX.GetPosition(1) - lineRendererY.GetPosition(0)).magnitude;
        //return 0;
    }
    public float GetVerticalDistanceDown()
    {
        return (lineRendererX.GetPosition(1).y - lineRendererX.GetPosition(2).y);
        //return 0;
    }

    public Vector3 GetVerticalDownPos()
    {
        return lineRendererX.GetPosition(2) + ((new Vector3(0, lineRendererX.GetPosition(1).y, 0) - new Vector3(0, lineRendererX.GetPosition(2).y, 0)) /2);
    }
    public Vector3 GetHorizontalFarPos()
    {
        return lineRendererX.GetPosition(1);
    }
}
