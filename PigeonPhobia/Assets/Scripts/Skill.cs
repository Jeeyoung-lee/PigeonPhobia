using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [Header("쿨타임")]
    [SerializeField]
    protected Text m_remainTime;
    [Header("스킬 선택 아이콘")]
    [SerializeField]
    protected Image m_check;
    [Header("쿨타임 배경")]
    [SerializeField]
    protected Image m_coolTimeBackground;

    protected float m_time;
    protected bool m_isUseable = true; // 사용 가능한 상태인가?
    protected bool m_isReady; // 준비 되었나?
    protected float m_coolTime;
    protected bool m_isPossession; // 보유중인가?

    protected Camera m_camera;

    public bool Useable
    {
        get { return m_isUseable; }
        set { m_isUseable = value; }
    }

    public bool Possession
    {
        get { return m_isPossession; }
        set { m_isPossession = value; }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        m_time = 0;
        m_isUseable = true;
        m_remainTime.gameObject.SetActive(false);
        m_check.gameObject.SetActive(false);
        m_coolTimeBackground.gameObject.SetActive(false);
    }

    public void Select()
    {
        m_isReady = true;
        m_check.gameObject.SetActive(true);
    }

    public void Clear()
    {
        m_isReady = false;
        m_check.gameObject.SetActive(false);
    }

    public void Use()
    {
        m_remainTime.gameObject.SetActive(true);
        m_check.gameObject.SetActive(false);
        m_coolTimeBackground.gameObject.SetActive(true);
    }

    public abstract void Create();

    public abstract GameObject GetItem();
}
