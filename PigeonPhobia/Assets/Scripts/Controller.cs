using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("비둘기 생성 시간")]
    [SerializeField]
    float m_pigeonAppearTime;

    [Header("음식 생성 시간")]
    [SerializeField]
    float m_foodAppearTime;
    [Header("한번에 생성되는 음식 개수")]
    [SerializeField]
    float m_foodCount;
}
