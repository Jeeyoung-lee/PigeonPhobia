using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager instance;

    [Header("둥지 프리팹")]
    [SerializeField]
    GameObject m_nestPrefab;
    [Header("둥지 프리팹 부모")]
    [SerializeField]
    Transform m_nestParent;
    [Header("둥지 프리팹 생성 범위")]
    [SerializeField]
    Collider2D m_nestRange;

    [Header("비둘기 프리팹")]
    [SerializeField]
    GameObject[] m_pigeonPrefab;

    [Header("비둘기 프리팹2")]
    [SerializeField]
    GameObject[] m_pigeonPrefab2;

    [Header("비둘기 프리팹3")]
    [SerializeField]
    GameObject[] m_pigeonPrefab3;

    [Header("비둘기 프리팹4")]
    [SerializeField]
    GameObject[] m_pigeonPrefab4;

    [Header("비둘기 프리팹5")]
    [SerializeField]
    GameObject[] m_pigeonPrefab5;

    [Header("비둘기 프리팹 부모")]
    [SerializeField]
    Transform m_pigeonParent;
    [Header("비둘기 프리팹 생성 범위")]
    [SerializeField]
    Collider2D m_pigeonRange;

    void Awake() => instance = this;

    /// <summary>
    /// 둥지 생성
    /// </summary>
    /// <returns></returns>
    public GameObject CreateNest()
    {
        var nest = Instantiate(m_nestPrefab, m_nestParent);
        var randomX = Random.Range(m_nestRange.bounds.min.x, m_nestRange.bounds.max.x);
        var randomY = Random.Range(m_nestRange.bounds.min.y, m_nestRange.bounds.max.y);
        nest.transform.position = new Vector2(randomX, randomY);
        nest.GetComponent<Nest>().Creationable = true;

        return nest;
    }

    /// <summary>
    /// 비둘기 랜덤 위치 생성
    /// </summary>
    /// <returns></returns>
    public GameObject CreatePigeonRandom()
    {      
        var index = Random.Range(0, GetPigeonArray().Length);
        var pigeon = Instantiate(GetPigeonArray()[index], m_pigeonParent);
        var randomX = Random.Range(m_pigeonRange.bounds.min.x, m_pigeonRange.bounds.max.x);
        var randomY = Random.Range(m_pigeonRange.bounds.min.y, m_pigeonRange.bounds.max.y);
        pigeon.transform.position = new Vector2(randomX, randomY);
        pigeon.GetComponent<Movement>().Run(m_pigeonRange);
        GameManager.instance.PlusCount();
        return pigeon;
    }

    /// <summary>
    /// 비둘기 둥지에서 생성
    /// </summary>
    /// <returns></returns>
    public GameObject CreatePigeonInNest()
    {
        var index = Random.Range(0, GetPigeonArray().Length);
        var pigeon = Instantiate(GetPigeonArray()[index], m_pigeonParent);
        //var randomX = Random.Range(m_pigeonRange.bounds.min.x, m_pigeonRange.bounds.max.x);
        //var randomY = Random.Range(m_pigeonRange.bounds.min.y, m_pigeonRange.bounds.max.y);
        //pigeon.transform.position = new Vector2(randomX, randomY);
        pigeon.GetComponent<Movement>().Run(m_pigeonRange);
        GameManager.instance.PlusCount();
        return pigeon;
    }

    GameObject[] GetPigeonArray()
    {
        var day = GameManager.instance.Day;

        switch (day)
        {
            case 1:
                return m_pigeonPrefab;
            case 2:
                return m_pigeonPrefab2;
            case 3:
                return m_pigeonPrefab3;
            case 4:
                return m_pigeonPrefab4;
            case 5:
                return m_pigeonPrefab5;
        }

        return null;
    }
}
