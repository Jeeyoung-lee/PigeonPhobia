using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    List<GameObject> m_pigeons = new List<GameObject>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!m_pigeons.Contains(collision.gameObject))
        {
            m_pigeons.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_pigeons.Contains(collision.gameObject))
        {
            m_pigeons.Remove(collision.gameObject);
        }
    }

    public List<GameObject> GetPigeonsList()
    {
        return m_pigeons;
    }
}
