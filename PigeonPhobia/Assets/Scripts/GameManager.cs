using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Text m_pigeonCountText;
    [SerializeField]
    GameObject m_ending;
    [SerializeField]
    Transform m_pigeonParent;
    [SerializeField]
    Transform m_nestParent;

    [SerializeField]
    FadeInOut m_fadeInOut;

    int m_pigeonCount; // 생성된 비둘기 수치
    const int m_maxPigeonCount = 50; // 비둘기 생성 가능 최대 수치

    GameObject m_skillItem;
    bool m_isEnding;
    int m_day = 1;
    bool m_isStart;

    public GameObject SkillItem => m_skillItem;
    public int Day => m_day;

    public bool isStart
    {
        get { return m_isStart; }
        set { m_isStart = value; }
    }

    void Awake() => instance = this;

    private void LateUpdate()
    {
        CheckPigeon();
        UpdateCount();
        CheckGame();
    }

    public void Init()
    {
        m_pigeonCount = 0;
    }

    public void PlusCount()
    {
        m_pigeonCount++;
        CheckEnding();
    }

    public void MinusCount()
    {
        m_pigeonCount--;
    }

    void UpdateCount()
    {
        //"<color=#ff0000>" + 10 + "</color>"
        if(m_pigeonCount >= 40)
        {
            m_pigeonCountText.text = "<color=#e51111>" + m_pigeonCount + "</color>" + " / " + m_maxPigeonCount;
        }
        else if(m_pigeonCount >= 30)
        {
            m_pigeonCountText.text = "<color=#ff9d0b>" + m_pigeonCount + "</color>" + " / " + m_maxPigeonCount;
        }
        else
        {
            m_pigeonCountText.text = "<color=#927fec>" + m_pigeonCount + "</color>" + " / " + m_maxPigeonCount;
        }
    }


    /// <summary>
    /// 스킬 장착
    /// </summary>
    public void SetSkillItem(GameObject _item)
    {
        m_skillItem = _item;
    }

    public void SetDay(int _day)
    {
        m_day = _day;
    }

    void CheckEnding()
    {
        if(m_pigeonCount >= 50 && !m_isEnding || m_day > 5 && !m_isEnding)
        {
            StartCoroutine(CWaitTime());
            m_fadeInOut.FadeIn();
            m_ending.SetActive(true);
            m_isEnding = true;
        }
    }

    IEnumerator CWaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public int GetPigeonCount()
    {
        return m_pigeonCount;
    }

    public void CheckPigeon()
    {
        if(m_pigeonCount != m_pigeonParent.childCount)
        {
            m_pigeonCount = m_pigeonParent.childCount;
        }
    }

    void CheckGame()
    {
        if (!isStart)
            return;

        if (m_pigeonCount <= 0 && m_nestParent.childCount <= 0)
        {
            Time.timeScale = 8;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
