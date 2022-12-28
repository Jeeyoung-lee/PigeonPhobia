using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    [SerializeField]
    int m_hp = 8;
    [Header("둥지에서 몇초마다 비둘기가 생성될 것인지")]
    [SerializeField]
    float m_creationTime;

    float m_time;

    bool m_isAttackable = true;

    GameManager m_gameManager;
    bool m_isCreationable = true; // 생성 가능한 상태인가?

    public bool Creationable
    {
        get { return m_isCreationable; }
        set { m_isCreationable = value; }
    }

    private void Update()
    {
        m_time += Time.deltaTime;
        if(m_time >= m_creationTime && m_isCreationable)
        {
            var prefabManager = PrefabManager.instance;
            var pigeon = prefabManager.CreatePigeonInNest();
            pigeon.transform.position = transform.position;
            m_time = 0;
        }
    }

    public void PointerDown()
    {
        if (!m_isAttackable)
            return;

        m_gameManager = GameManager.instance;

        if (m_gameManager.SkillItem != null)
        {
            var skillType = m_gameManager.SkillItem.GetComponent<SkillInfo>().GetSkillType();

            if (skillType == "A")
            {
                m_hp -= 8;
                FindObjectOfType<SkillA>().Useable = false;
            }
            else if (skillType == "S")
            {
                FindObjectOfType<SkillS>().Useable = false;
                var list = m_gameManager.SkillItem.GetComponent<TriggerChecker>().GetPigeonsList();
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    Destroy(list[i].gameObject);
                }
            }

            Destroy(m_gameManager.SkillItem);
            m_gameManager.SetSkillItem(null);
        }

        m_hp -= 1;

        if (m_hp <= 0)
            Destroy(this.gameObject);
    }
}
