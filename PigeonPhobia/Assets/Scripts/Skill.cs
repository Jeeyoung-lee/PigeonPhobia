using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [Header("��Ÿ��")]
    [SerializeField]
    protected Text m_remainTime;
    [Header("��ų ���� ������")]
    [SerializeField]
    protected Image m_check;
    [Header("��Ÿ�� ���")]
    [SerializeField]
    protected Image m_coolTimeBackground;

    protected float m_time;
    protected bool m_isUseable = true; // ��� ������ �����ΰ�?
    protected bool m_isReady; // �غ� �Ǿ���?
    protected float m_coolTime;
    protected bool m_isPossession; // �������ΰ�?

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
