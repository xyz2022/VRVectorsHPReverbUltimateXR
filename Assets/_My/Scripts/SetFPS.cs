using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetFPS : MonoBehaviour
{
    private float period = 0.0f;
    public float logSeconds = 5f;

    // Start is called before the first frame update
    void Start()
    {
        float[] freqs = { 0, 0 };// OVRManager.display.displayFrequenciesAvailable;

        /*if (freqs.Contains(120f))
        {
            OVRPlugin.systemDisplayFrequency = 120f;
        }
        else */if (freqs.Contains(90f))
        {
            //OVRPlugin.systemDisplayFrequency = 90f;
        }
        else if (freqs.Contains(60f))
        {
            //OVRPlugin.systemDisplayFrequency = 80f;
        }
        else if (freqs.Contains(60f))
        {
            //OVRPlugin.systemDisplayFrequency = 72f;
        }
        else if (freqs.Contains(60f))
        {
            //OVRPlugin.systemDisplayFrequency = 60f;
        }
        else
        {
            Debug.Log("FPS: unable to set FPS");
            return;
        }
        
        LogFPS();

    }

    // Update is called once per frame
    void Update()
    {
        if (period > logSeconds)
        {
            LogFPS();
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }

    public void LogFPS()
        //public because called by external script
    {
        //Debug.Log("FPS: " + OVRPlugin.systemDisplayFrequency.ToString() + " hz");
    }
}
