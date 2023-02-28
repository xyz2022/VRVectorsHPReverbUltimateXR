using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsOnReleased : MonoBehaviour
{
    TrailRenderer trailRenderer;
    EmitParticles emitParticles; 
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;
        emitParticles = GetComponent<EmitParticles>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTrail()
    {
        trailRenderer.Clear();
        trailRenderer.emitting = true;
        emitParticles.EmitNow();
    }

    public void StopTrail()
    {
        trailRenderer.emitting = false;
    }
    public void ResetTrail()
    {
        trailRenderer.Clear();
    }

}
