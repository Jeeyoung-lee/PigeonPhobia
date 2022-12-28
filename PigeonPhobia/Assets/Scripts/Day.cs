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

    [SerializeField]
    StageSetting m_stageSetting;

    private void Update()
    {
        m_dayTime -= Time.deltaTime;
        m_dayTimeText.text = ((int)m_dayTime).ToString();

        m_peakTime.SetTime(m_dayTime);

        if (m_dayTime <= 0)
        {
            m_fadeInOut.FadeIn(1f);
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
        var stageArray = m_stageSetting.SetStage(m_day);
        foreach(var stage in stageArray)
        {
            if (pigeonCount <= stage.m_standardPigeonCount)
            {
                m_startSetting.CreatePigeon(stage.m_additionalPigeon);
                m_startSetting.CreateNest(stage.m_additionalNest);
                break;
            }
        }
    }

    IEnumerator CWaitTime()
    {
        yield return new WaitForSeconds(1f);
        StageInit();
        Time.timeScale = 0;
    }
}
