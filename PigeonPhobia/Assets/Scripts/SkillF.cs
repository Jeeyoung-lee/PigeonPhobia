using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillF : Skill
{
    [SerializeField]
    GameObject m_skillFPrefab;
    [SerializeField]
    Transform m_skillFParent;
    [SerializeField]
    Sprite m_skillFSprite;

    GameObject m_item;

    private void Start()
    {
        m_camera = Camera.main;
        m_coolTime = 5;
        Init();
    }

    private void Update()
    {
        if (m_item != null)
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
                m_coolTime = 5;
            }
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
        m_item = Instantiate(m_skillFPrefab, m_skillFParent);
        GameManager.instance.SetSkillItem(m_item);
    }

    public override GameObject GetItem()
    {
        return m_item;
    }

    public override void SetImage()
    {
        m_skillImage.sprite = m_skillFSprite;
    }
}
