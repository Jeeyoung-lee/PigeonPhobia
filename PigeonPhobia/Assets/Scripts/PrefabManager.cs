using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager instance;

    [Header("���� ������")]
    [SerializeField]
    GameObject m_nestPrefab;
    [Header("���� ������ �θ�")]
    [SerializeField]
    Transform m_nestParent;
    [Header("���� ������ ���� ����")]
    [SerializeField]
    Collider2D m_nestRange;

    [Header("��ѱ� ������")]
    [SerializeField]
    GameObject m_pigeonPrefab;
    [Header("��ѱ� ������ �θ�")]
    [SerializeField]
    Transform m_pigeonParent;
    [Header("��ѱ� ������ ���� ����")]
    [SerializeField]
    Collider2D m_pigeonRange;

    void Awake() => instance = this;

    /// <summary>
    /// ���� ����
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
    /// ��ѱ� ���� ��ġ ����
    /// </summary>
    /// <returns></returns>
    public GameObject CreatePigeonRandom()
    {
        var pigeon = Instantiate(m_pigeonPrefab, m_pigeonParent);
        var randomX = Random.Range(m_pigeonRange.bounds.min.x, m_pigeonRange.bounds.max.x);
        var randomY = Random.Range(m_pigeonRange.bounds.min.y, m_pigeonRange.bounds.max.y);
        pigeon.transform.position = new Vector2(randomX, randomY);
        pigeon.GetComponent<Movement>().Run(m_pigeonRange);
        GameManager.instance.PlusCount();
        return pigeon;
    }

    /// <summary>
    /// ��ѱ� �������� ����
    /// </summary>
    /// <returns></returns>
    public GameObject CreatePigeonInNest()
    {
        var pigeon = Instantiate(m_pigeonPrefab, m_pigeonParent);
        //var randomX = Random.Range(m_pigeonRange.bounds.min.x, m_pigeonRange.bounds.max.x);
        //var randomY = Random.Range(m_pigeonRange.bounds.min.y, m_pigeonRange.bounds.max.y);
        //pigeon.transform.position = new Vector2(randomX, randomY);
        pigeon.GetComponent<Movement>().Run(m_pigeonRange);
        GameManager.instance.PlusCount();
        return pigeon;
    }
}
