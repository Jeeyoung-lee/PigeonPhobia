using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Text m_pigeonCountText;

    int m_pigeonCount;
    const int m_maxPigeonCount = 50;

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
}
