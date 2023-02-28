using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EmitParticles : MonoBehaviour
{
    public GameObject pointOfOrigin;
    //public ParticleSystem particleSystem;

    public void EmitNow()
    {
        GameObject particlePooledObject = SetupObjectPoolParticles.SharedInstance.GetPooledObject();
        if (particlePooledObject != null)
        {
            particlePooledObject.transform.position = pointOfOrigin.transform.position;
            //particlePooledObject.transform.position -= new Vector3(0, 2, 0);
            particlePooledObject.SetActive(true);
            particlePooledObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
