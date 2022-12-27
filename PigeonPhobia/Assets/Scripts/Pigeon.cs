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
        if(collision.GetComponent<Food>() != null)
        {
            var hp = collision.GetComponent<Food>().GetFoodHP();
            m_hp += hp;
            size += hp * 0.1f;
        }

        if(m_hp >= 10)
        {
            PrefabManager.instance.CreateNest(); // 둥지 생성
        }

        Destroy(collision.gameObject);
    }

    public void PointerDown()
    {
        if (!m_isAttackable)
            return;

        m_hp -= 1;

        StartCoroutine(CWaitForTime());

        if (m_hp <= 0)
        {
            m_gameManager.MinusCount();
            Destroy(this.gameObject);
        }
    }

    IEnumerator CWaitForTime()
    {
        m_isAttackable = false;
        yield return new WaitForSeconds(0.14f);
        m_isAttackable = true;
    }
}
