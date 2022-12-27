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

    private void Update()
    {
        m_dayTime -= Time.deltaTime;
        m_dayTimeText.text = ((int)m_dayTime).ToString();

        if(m_dayTime <= 0)
        {
            m_shop.gameObject.SetActive(true);
            Init();
            Time.timeScale = 0;
            m_day++;
            GameManager.instance.SetDay(m_day);
            m_dayText.text = m_day.ToString();
            m_dayTime = 60;
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

        //foreach (Transform element in m_pigeonList)
        //{
        //    Destroy(element.gameObject);
        //}
    }

}
