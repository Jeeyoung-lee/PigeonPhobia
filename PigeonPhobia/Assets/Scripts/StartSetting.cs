using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{
    [Header("시작시 생성될 비둘기 수")]
    [SerializeField]
    int m_startPigeonCount;
    [Header("시작시 생성될 둥지 개수")]
    [SerializeField]
    int m_startNestCount;

    [SerializeField]
    FadeInOut m_fadeInOut;

    private void Start()
    {
        m_fadeInOut.FadeIn();
        Init();
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
