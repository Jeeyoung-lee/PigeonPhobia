using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : Food
{
    [Header("HP Αυ°‘·®")]
    [SerializeField]
    int m_hp = 10;

    protected override int GetHP()
    {
        return m_hp;
    }
}
