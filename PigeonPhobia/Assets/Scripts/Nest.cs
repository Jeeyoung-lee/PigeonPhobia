using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{
    [SerializeField]
    int m_hp = 15;
    [SerializeField]
    float m_duration;

    float m_time;

    bool m_isAttackable = true;

    private void Update()
    {
        m_time += Time.deltaTime;
        if(m_time >= m_duration)
        {
            PrefabManager.instance.CreatePigeon();
            m_time = 0;
        }
    }

    public void PointerDown()
    {
        if (!m_isAttackable)
            return;

        m_hp -= 1;

        StartCoroutine(CWaitForTime());

        if (m_hp <= 0)
            Destroy(this.gameObject);
    }

    IEnumerator CWaitForTime()
    {
        m_isAttackable = false;
        yield return new WaitForSeconds(0.14f);
        m_isAttackable = true;
    }
}
