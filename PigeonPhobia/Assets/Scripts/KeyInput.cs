using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    [SerializeField]
    Skill[] m_skills;

    GameObject m_item;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (!m_skills[0].Useable || !m_skills[0].Possession)
                return;

            DestoryItem();
            m_skills[0].Select();
            m_skills[0].Create();
            m_item = m_skills[0].GetItem();
            Clear(0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!m_skills[1].Useable || !m_skills[1].Possession)
                return;

            DestoryItem();
            m_skills[1].Select();
            m_skills[1].Create();
            m_item = m_skills[1].GetItem();
            Clear(1);
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    m_skills[2].Select();
        //    Clear(2);
        //}

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    m_skills[3].Select();
        //    Clear(3);
        //}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < m_skills.Length; i++)
            {
                m_skills[i].Init();
            }

            Destroy(m_item.gameObject);
            GameManager.instance.SetSkillItem(null);
        }
    }

    void Clear(int _index)
    {
        for(int i = 0; i < m_skills.Length; i++)
        {
            if (i == _index)
                continue;

            m_skills[i].Clear();
        }
    }

    void DestoryItem()
    {
        if(m_item != null)
        {
            Destroy(m_item.gameObject);
            GameManager.instance.SetSkillItem(null);
        }
    }
}
