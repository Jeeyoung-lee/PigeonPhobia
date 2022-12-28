using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartSetting : MonoBehaviour
{
    [Header("���۽� ������ ��ѱ� ��")]
    [SerializeField]
    int m_startPigeonCount;
    [Header("���۽� ������ ���� ����")]
    [SerializeField]
    int m_startNestCount;

    [SerializeField]
    FadeInOut m_fadeInOut;

    [SerializeField]
    GameObject m_story;

    [SerializeField]
    AudioSource m_audio;

    AudioSource m_title;

    private void Start()
    {
        Time.timeScale = 0;
        m_title = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        m_title.DOFade(0, 2f);
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        m_story.SetActive(false);
        m_fadeInOut.FadeIn();
        StartCoroutine(CWaitTime());
    }

    IEnumerator CWaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        Init();
        GameManager.instance.isStart = true;
        m_audio.enabled = true;
    }

    public void Init()
    {
        for (int i = 0; i < m_startPigeonCount; i++)
        {
            PrefabManager.instance.CreatePigeonRandom();
        }

        for (int i = 0; i < m_startNestCount; i++)
        {
            PrefabManager.instance.CreateNest();
        }
    }

    public void CreatePigeon(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            PrefabManager.instance.CreatePigeonRandom();
        }
    }

    public void CreateNest(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            PrefabManager.instance.CreateNest();
        }
    }
}
