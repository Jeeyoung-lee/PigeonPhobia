using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Text m_pigeonCountText;

    int m_pigeonCount; // 생성된 비둘기 수치
    const int m_maxPigeonCount = 50; // 비둘기 생성 가능 최대 수치

    GameObject m_skillItem;

    public GameObject SkillItem => m_skillItem;

    void Awake() => instance = this;

    public void PlusCount()
    {
        m_pigeonCount++;
        UpdateCount();
    }

    public void MinusCount()
    {
        m_pigeonCount--;
        UpdateCount();
    }

    void UpdateCount()
    {
        //"<color=#ff0000>" + 10 + "</color>"
        if(m_pigeonCount >= 40)
        {
            m_pigeonCountText.text = "<color=#ff0000>" + m_pigeonCount + "</color>" + " / " + m_maxPigeonCount;
        }
        else
        {
            m_pigeonCountText.text = "<color=#323232>" + m_pigeonCount + "</color>" + " / " + m_maxPigeonCount;
        }

    }

    /// <summary>
    /// 스킬 장착
    /// </summary>
    public void SetSkillItem(GameObject _item)
    {
        m_skillItem = _item;
    }
}
