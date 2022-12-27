using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : Food
{
    [Header("HP Αυ°‘·®")]
    [SerializeField]
    int m_hp = 5;

    protected override int GetHP()
    {
        return m_hp;
    }
}
