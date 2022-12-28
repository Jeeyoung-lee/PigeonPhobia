using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day : MonoBehaviour
{
    [SerializeField]
    Text m_dayTimeText;
    [SerializeField]
    Text m_dayText;

    [Header("하루 시간")]
    [SerializeField]
    float m_dayTime;
    [SerializeField]
    int m_day = 1;

    [Header("비둘기가 몇 마리 이하일때")]
    [SerializeField]
    int m_standardPigeonCount;
    [Header("추가로 생성할 비둘기")]
    [SerializeField]
    int m_additionalPigeon;
    [Header("추가로 생성할 둥지")]
    [SerializeField]
    int m_additionalNest;


    [SerializeField]
    Shop m_shop;

    [SerializeField]
    Transform m_foodList;
    [SerializeField]
    Transform m_pigeonList;
    [SerializeField]
    Transform m_nestList;

    [SerializeField]
    PeakTime m_peakTime;

    [SerializeField]
    StartSetting m_startSetting;

    [SerializeField]
    FadeInOut m_fadeInOut;

    private void Update()
    {
        m_dayTime -= Time.deltaTime;
        m_dayTimeText.text = ((int)m_dayTime).ToString();

        m_peakTime.SetTime(m_dayTime);

        if (m_dayTime <= 0)
        {
            m_fadeInOut.FadeIn();
            m_shop.gameObject.SetActive(true);
            Init();

            m_day++;
            GameManager.instance.SetDay(m_day);
            m_dayText.text = m_day.ToString();
            m_dayTime = 61;
        }
    }

    void Init()
    {
        foreach(Transform element in m_foodList)
        {
            Destroy(element.gameObject);
        }

        foreach (Transform element in m_nestList)
        {
            Destroy(element.gameObject);
        }

        StartCoroutine(CWaitTime());
        //foreach (Transform element in m_pigeonList)
        //{
        //    Destroy(element.gameObject);
        //}
    }

    void StageInit()
    {
        var pigeonCount = GameManager.instance.GetPigeonCount(); // 남아 있는 비둘기 수
        if(pigeonCount <= m_standardPigeonCount)
        {
            m_startSetting.CreatePigeon(m_additionalPigeon);
            m_startSetting.CreateNest(m_additionalNest);
        }
    }

    IEnumerator CWaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        StageInit();
        Time.timeScale = 0;
    }
}
