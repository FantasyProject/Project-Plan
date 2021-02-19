using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 해당 스크립트를 사용하려면 Image Component가 있어야 합니다.
// Panel에 해당 스크립트를 붙이시면 됩니다.
[RequireComponent(typeof(Image))]
public class Screen_FadeIn : MonoBehaviour
{
    private GameObject _panelObj;
    [SerializeField]private Image _image;
    [SerializeField] private float Screen_FadeInTime = 2.0f;
    [SerializeField] private int Screen_FadeInFrequency = 25; 
    
    private void Awake()
    {
        _panelObj = this.gameObject;
        _image = _panelObj.GetComponent<Image>();

        Color _color = _image.color;
        _color.a = 1;
        _image.color = _color;
    }

    private void Start()
    {
        StartCoroutine(ScreenFadeInCoroutine());
    }

    IEnumerator ScreenFadeInCoroutine()
    {
        int i = Screen_FadeInFrequency;
        Color c = _image.color;
        while (i > 0)
        {
            i = i - 1;
            float Screen_alpha = i / (float)Screen_FadeInFrequency;
            c.a = Screen_alpha;
            _image.color = c;
            yield return new WaitForSeconds(Screen_FadeInTime / Screen_FadeInFrequency);
        }

        yield return null;
    }
    
    // 외부 스크립트에서 호출 할 메소드
    public void CallingScreenFadeIn(int frequency, float delay)
    {
        Screen_FadeInTime = delay;
        Screen_FadeInFrequency = frequency;
        StartCoroutine(ScreenFadeInCoroutine());
    }
}
