using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pigeon : MonoBehaviour
{
    [Header("비둘기 체력")]
    [SerializeField]
    float m_hp = 3;

    float m_time; 
    float m_nestTime = 5;

    Image m_owner;
    float m_prevPositionX;

    float size = 1;
    bool m_isAttackable = true;

    GameManager m_gameManager;

    private void Start()
    {
        m_owner = GetComponent<Image>();
        m_gameManager = GameManager.instance;
    }

    private void Update()
    {
        m_prevPositionX = transform.position.x;

        if (m_hp >= 10)
        {
            m_time += Time.deltaTime;
            if(m_time >= m_nestTime)
            {
                PrefabManager.instance.CreateNest(); // 둥지 생성
                m_time = 0;
            }

        }
    }

    private void LateUpdate()
    {
        SetDirection();
    }

    void SetDirection()
    {
        if (m_prevPositionX < transform.position.x)
            m_owner.transform.localScale = new Vector3(-size, size, 1);
        else
            m_owner.transform.localScale = new Vector3(size, size, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "food")
        {
            if (collision.GetComponent<Food>() != null)
            {
                var hp = collision.GetComponent<Food>().GetFoodHP();
                m_hp += hp;
                size += hp * 0.1f;
            }



            Destroy(collision.gameObject);
        }

    }

    public void PointerDown()
    {
        if (!m_isAttackable)
            return;

        if(m_gameManager.SkillItem != null)
        {
            var skillType = m_gameManager.SkillItem.GetComponent<SkillInfo>().GetSkillType();
            
            if(skillType == "A")
            {
                m_hp -= 999;
                FindObjectOfType<SkillA>().Useable = false;
            }
            else if(skillType == "S")
            {
                FindObjectOfType<SkillS>().Useable = false;
                var list = m_gameManager.SkillItem.GetComponent<TriggerChecker>().GetPigeonsList();
                for(int i = list.Count - 1; i >= 0; i--)
                {
                    m_gameManager.MinusCount();
                    Destroy(list[i].gameObject);
                }
            }
            else if(skillType == "D")
            {
                FindObjectOfType<SkillD>().Useable = false;
            }
            else if(skillType == "F")
            {
                FindObjectOfType<SkillF>().Useable = false;
            }

            Destroy(m_gameManager.SkillItem);
            m_gameManager.SetSkillItem(null);
        }

        m_hp -= 1;

        if (m_hp <= 0)
        {
            m_gameManager.MinusCount();
            Destroy(this.gameObject);
        }
    }

    public void Damaged(int _damage)
    {
        if (!m_isAttackable)
            return;

        m_hp -= _damage;

        if (m_hp <= 0)
        {
            m_gameManager.MinusCount();
            Destroy(this.gameObject);
        }
    }
}
