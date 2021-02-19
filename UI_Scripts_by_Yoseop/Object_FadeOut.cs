using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해당 스크립트를 사용하려면 Matertial, Renderer Component가 있어야 합니다.
// 그리고 Material은 Transparent를 지원해줘야 합니다.
// 테스트용 Material로 Legacy Shaders/Transparent/Diffuse를 사용하였습니다.

[RequireComponent(typeof(Material), typeof(Renderer))]
public class Object_FadeOut : MonoBehaviour
{
    private Renderer _objectRenderer;    
    [SerializeField]private float FadeOutTime = 2.0f;
    [SerializeField]private int FadeOutFrequency = 25;
    
    private void Start()
    {
        _objectRenderer = gameObject.GetComponent<Renderer>();
        StartCoroutine(ObjectFadeOutCoroutine());
    }

    private IEnumerator ObjectFadeOutCoroutine()
    {
        int i = FadeOutFrequency;
        while (i > 0)
        {
            i = i - 1;
            float color_alpha = i / (float)FadeOutFrequency;
            Color c = _objectRenderer.material.color;
            c.a = color_alpha;
            _objectRenderer.material.color = c;

            yield return new WaitForSeconds(FadeOutTime / FadeOutFrequency);
        }
    }

    // 외부 스크립트에서 호출 할 메소드
    public void CallingFadeOut(int frequency, float time)
    {
        FadeOutTime = time;
        FadeOutFrequency = frequency;
        StartCoroutine(ObjectFadeOutCoroutine());
    }
}
