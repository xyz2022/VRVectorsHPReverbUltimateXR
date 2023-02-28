using System;
using UnityEngine;
using UnityEngine.Events;

public class ProcessInput : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] XRBinding[] bindings;
#pragma warning restore 0649

    private void Update()
    {
        foreach (var binding in bindings)
            binding.Update();
    }
}

[Serializable]
public class XRBinding
{
#pragma warning disable 0649
    [SerializeField] UnityEvent taskToRun;
    //[SerializeField] OVRInput.Button button;
    //[SerializeField] OVRInput.Controller controller;
#pragma warning restore 0649
    
    public void Update()
    {
      //  if (OVRInput.Get(button, controller))
      //      Debug.Log(OVRInput.Axis1D.PrimaryIndexTrigger.ToString());
            //taskToRun.Invoke();
    }
}