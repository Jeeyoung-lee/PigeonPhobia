using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stage
{
    [Header("��ѱⰡ �� ���� �����϶�")]
    public int m_standardPigeonCount;
    [Header("�߰��� ������ ��ѱ�")]
    public int m_additionalPigeon;
    [Header("�߰��� ������ ����")]
    public int m_additionalNest;
}

public class StageSetting : MonoBehaviour
{
    [SerializeField]
    Stage[] m_stage2;
    [SerializeField]
    Stage[] m_stage3;
    [SerializeField]
    Stage[] m_stage4;
    [SerializeField]
    Stage[] m_stage5;

    public Stage[] SetStage(int _day)
    {
        switch(_day)
        {
            case 2:
                return m_stage2;
            case 3:
                return m_stage3;
            case 4:
                return m_stage4;
            case 5:
                return m_stage5;
        }

        return null;
    }
}
