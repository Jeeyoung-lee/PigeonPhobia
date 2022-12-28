using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    Image m_image;
    [SerializeField]
    float m_duration;

    public void FadeIn()
    {
        m_image.DOFade(1, 0).OnComplete(() => m_image.DOFade(0, m_duration));
    }

    public void FadeOut()
    {
        m_image.DOFade(0, 0).OnComplete(() => m_image.DOFade(1, m_duration));
    }

    public void FadeIn(float _time)
    {
        m_image.DOFade(1, 0).OnComplete(() => m_image.DOFade(0, _time));
    }
}
