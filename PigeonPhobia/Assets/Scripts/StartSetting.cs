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
}