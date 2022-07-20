using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTrail : MonoBehaviour
{
    public TrailRenderer _trail;

    private void Start() {
        _trail =  GetComponent<TrailRenderer>();
    }
    


    public void ChangeTrailState(bool emitting, float time)
    {
        _trail.emitting = emitting;
        _trail.time = time;
    }
}
