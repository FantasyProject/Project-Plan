using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 해당 스크립트를 사용하려면 Image Component가 있어야 합니다.
// Panel에 해당 스크립트를 붙이시면 됩니다.
[RequireComponent(typeof(Image))]
public class Icon_Sinked_FadeOut : MonoBehaviour
{
    private GameObject _panelObj;
    [SerializeField]private Image _image;
    [SerializeField] private float Clock_FadeOutTime = 2.0f; 
    [SerializeField] private int Clock_FadeOutFrequency = 25;

    private void Awake()
    {
        _panelObj = this.gameObject;
        _image = _panelObj.GetComponent<Image>();

        // Image type 초기화
        _image.type = Image.Type.Filled;
        _image.fillMethod = Image.FillMethod.Vertical;
        _image.fillOrigin = (int)Image.Origin360.Bottom;
        _image.fillAmount = 1.0f;
    }

    private void Start()
    {
        StartCoroutine(IconSinkedFadeOutCoroutine());
    }

    IEnumerator IconSinkedFadeOutCoroutine()
    {
        int i = Clock_FadeOutFrequency;
        while (i > 0)
        {
            i = i - 1;
            _image.fillAmount = i / (float)Clock_FadeOutFrequency;
            yield return new WaitForSeconds(Clock_FadeOutTime / Clock_FadeOutFrequency);
        }

        yield return null;
    }

    // 외부 스크립트에서 호출 할 메소드
    public void CallingSinkedFadeOut(int frequency, float time)
    {
        Clock_FadeOutTime = time;
        Clock_FadeOutFrequency = frequency;

        StartCoroutine(IconSinkedFadeOutCoroutine());
    }
}
