using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeakTime : MonoBehaviour
{
    [Header("첫번째 피크타임")]
    [SerializeField]
    float m_firstPeakTime;
    [Header("두번째 피크타임")]
    [SerializeField]
    float m_secondPeakTime;
    [Header("피크타임 지속시간")]
    [SerializeField]
    float m_duration;

    [SerializeField]
    PigeonFood m_pigeonFood;

    float m_time;
    bool m_isPeakTime;

    bool m_firstEvent;
    bool m_secondEvent;

    public void SetTime(float _time)
    {
        if(!m_firstEvent)
        {
            if (_time <= m_firstPeakTime && !m_isPeakTime)
            {
                m_isPeakTime = true;
                m_pigeonFood.CreationTime = m_pigeonFood.CreationTime - (m_pigeonFood.CreationTime * 30) / 100;
            }

            if (m_isPeakTime)
            {
                m_time += Time.deltaTime;
                if (m_time >= m_duration)
                {
                    m_pigeonFood.InitTime();
                    m_time = 0;
                    m_isPeakTime = false;
                    m_firstEvent = true;
                }
            }
        }

        if(!m_secondEvent)
        {
            if (_time <= m_secondPeakTime && !m_isPeakTime)
            {
                m_isPeakTime = true;
                m_pigeonFood.CreationTime = m_pigeonFood.CreationTime - (m_pigeonFood.CreationTime * 30) / 100;
            }

            if (m_isPeakTime)
            {
                m_time += Time.deltaTime;
                if (m_time >= m_duration)
                {
                    m_pigeonFood.InitTime();
                    m_time = 0;
                    m_isPeakTime = false;
                    m_secondEvent = true;
                }
            }
        }
    }
}
