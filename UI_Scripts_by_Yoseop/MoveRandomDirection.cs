using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MoveRandomDirection : MonoBehaviour
{
    private Vector3 _direction;
    
    private void ResetAnim()
    {
        // transform.position = Vector3.zero;
        _direction = new Vector3(
            UnityEngine.Random.Range(-1f, 1f), 
            UnityEngine.Random.Range(-1f, 1f), 
            -1).normalized;
    }

    private void MRD()
    {
        transform.Translate(_direction * Time.deltaTime);
    }

    private void CancleMRD()
    {
        CancelInvoke("MRD");
    }

    public void CallingMoveRandomDirection(float _playTime)
    {
        ResetAnim();

        InvokeRepeating("MRD", 0, 0.1f);
        Invoke("CancleMRD", _playTime);
    }
}
