using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 해당 스크립트를 사용하려면 Image Component가 있어야 합니다.
// Panel에 해당 스크립트를 붙이시면 됩니다.
[RequireComponent(typeof(Image))]
public class Screen_FadeOut : MonoBehaviour
{
    private GameObject _panelObj;
    [SerializeField]private Image _image;
    [SerializeField] private float Screen_FadeOutTime = 2.0f; 
    [SerializeField] private int Screen_FadeOutFrequency = 25; 
    
    private void Awake()
    {
        _panelObj = this.gameObject;
        _image = _panelObj.GetComponent<Image>();

        Color _color = _image.color;
        _color.a = 0;
        _image.color = _color;
    }

    IEnumerator ScreenFadeOutCoroutine()
    {
        int i = 0;
        Color c = _image.color;
        while (i < Screen_FadeOutFrequency)
        {
            i = i + 1;
            float Screen_alpha = i / (float)Screen_FadeOutFrequency;
            c.a = Screen_alpha;
            _image.color = c;
            yield return new WaitForSeconds(Screen_FadeOutTime / Screen_FadeOutFrequency);
        }

        yield return null;
    }
    
    // 외부 스크립트에서 호출 할 메소드
    public void CallingScreenFadeOut(int frequency, float time)
    {
        Screen_FadeOutTime = time;
        Screen_FadeOutFrequency = frequency;
        StartCoroutine(ScreenFadeOutCoroutine());
    }
}
