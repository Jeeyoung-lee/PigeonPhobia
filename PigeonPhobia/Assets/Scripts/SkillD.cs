using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillD : Skill
{
    [SerializeField]
    GameObject m_skillDPrefab;
    [SerializeField]
    Transform m_skillDParent;
    [SerializeField]
    Sprite m_skillDSprite;

    GameObject m_item;
    bool m_useSkill;

    private void Start()
    {
        m_camera = Camera.main;
        m_coolTime = 8;
        Init();
    }

    private void Update()
    {
        if (m_item != null && !m_useSkill)
            Update_MousePosition();

        if (!m_isUseable && m_coolTime >= 0) // 쿨타임 상태라면
        {
            Use();
            m_coolTime -= Time.deltaTime;
            m_remainTime.text = ((int)m_coolTime).ToString();

            if (m_coolTime <= 0)
            {
                Init();
                m_isUseable = true;
                m_coolTime = 8;
            }
        }

        if (Input.GetMouseButtonDown(0)) // 덫 설치
        {
            if (!m_isPossession || m_item == null)
                return;

            m_item.GetComponent<BoxCollider2D>().isTrigger = true;
            m_useSkill = true;
            Update_MousePosition();
        }

    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        var pos = m_camera.ScreenToWorldPoint(mousePos);
        m_item.transform.position = new Vector3(pos.x, pos.y, 1);
    }

    public override void Create()
    {
        m_useSkill = false;
        m_item = Instantiate(m_skillDPrefab, m_skillDParent);
        GameManager.instance.SetSkillItem(m_item);
    }

    public override GameObject GetItem()
    {
        return m_item;
    }

    public override void SetImage()
    {
        m_skillImage.sprite = m_skillDSprite;
    }
}
