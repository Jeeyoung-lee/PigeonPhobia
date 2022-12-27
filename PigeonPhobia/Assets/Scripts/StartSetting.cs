using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{
    [Header("���۽� ������ ��ѱ� ��")]
    [SerializeField]
    int m_startPigeonCount;
    [Header("���۽� ������ ���� ����")]
    [SerializeField]
    int m_startNestCount;

    private void Start()
    {
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
