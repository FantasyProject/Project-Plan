using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해당 스크립트는 필요한 컴포넌트가 없습니다.
public class CycleAnimation : MonoBehaviour
{
    public Vector3 _direction;
    public int _rotationSpeed = -60;
    
    private void CA()
    {
        // transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        transform.Rotate(_direction * (_rotationSpeed * Time.deltaTime));
    }

    private void CancleCA()
    {
        CancelInvoke("CA");
    }
    
    private void Reset()
    {
        transform.rotation = Quaternion.identity;
    }

    public void CallCycleAnimation(Vector3 _dir, float _speed, float _playTime)
    {
        _direction = _dir;
        InvokeRepeating("CA", 0, 0.1f);
        Invoke("CancleCA", _playTime);
    }
}
