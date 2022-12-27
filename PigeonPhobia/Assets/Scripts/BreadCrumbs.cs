using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumbs : Food
{
    [Header("HP ������")]
    [SerializeField]
    int m_hp;

    protected override int GetHP()
    {
        return m_hp;
    }
}
