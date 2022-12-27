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
    GameObject m_pigeonPrefab;
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
        return nest;
    }

    /// <summary>
    /// 비둘기 생성
    /// </summary>
    /// <returns></returns>
    public GameObject CreatePigeon()
    {
        var pigeon = Instantiate(m_pigeonPrefab, m_pigeonParent);
        var randomX = Random.Range(m_pigeonRange.bounds.min.x, m_pigeonRange.bounds.max.x);
        var randomY = Random.Range(m_pigeonRange.bounds.min.y, m_pigeonRange.bounds.max.y);
        pigeon.transform.position = new Vector2(randomX, randomY);
        pigeon.GetComponent<Movement>().Run(m_pigeonRange);
        GameManager.instance.PlusCount();
        return pigeon;
    }
}
