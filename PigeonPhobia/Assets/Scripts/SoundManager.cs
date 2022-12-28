using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    AudioSource m_mainAudioSource;
    [SerializeField]
    AudioSource m_subAudioSource;
    [SerializeField]
    AudioSource m_effect;

    // 오디오 클립
    [SerializeField]
    AudioClip m_gameBackground;
    [SerializeField]
    AudioClip m_shopBackground;
    [SerializeField]
    AudioClip[] m_skillSounds;
    [SerializeField]
    AudioClip[] m_endingSounds;

    void Awake() => instance = this;

    public void PlayShopSound()
    {
        m_mainAudioSource.DOFade(0, 1.5f);
        m_subAudioSource.Play();
        m_subAudioSource.DOFade(1, 1.5f);
    }

    public void PlayGameSound()
    {
        m_subAudioSource.DOFade(0, 1.5f);
        m_mainAudioSource.DOFade(1, 1.5f);
    }
}
