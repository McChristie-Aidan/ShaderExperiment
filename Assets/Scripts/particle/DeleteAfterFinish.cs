using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DeleteAfterFinish : MonoBehaviour
{
    VisualEffect visual;
    bool hasFired;

    private void Start()
    {
        visual = GetComponentInChildren<VisualEffect>();
    }
    private void Update()
    {
        if (visual.aliveParticleCount <= 0 && hasFired)
        {
            Destroy(this.gameObject);
        }
        if (!hasFired && visual.aliveParticleCount > 0)
        {
            this.hasFired = true;
        }
    }
}
