using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumbs : Food
{
    [Header("HP Αυ°‘·®")]
    [SerializeField]
    int m_hp = 3;

    protected override int GetHP()
    {
        return m_hp;
    }
}
