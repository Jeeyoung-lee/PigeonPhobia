using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearancePigeon : MonoBehaviour
{
    [Header("비둘기 생성 시간")]
    [SerializeField]
    float m_time;
    [SerializeField]
    Collider2D _range;
    [SerializeField]
    GameObject m_pigeonPrefab;
    [SerializeField]
    Transform m_pigeonParent;

    GameManager m_gameManager;

    float m_curTime;

    private void Start()
    {
        m_gameManager = GameManager.instance;
    }

    private void Update()
    {
        //m_curTime += Time.deltaTime;
        //if(m_time < m_curTime)
        //{
        //    var prefab = Instantiate(m_pigeonPrefab, m_pigeonParent);
        //    var randomX = Random.Range(_range.bounds.min.x, _range.bounds.max.x);
        //    var randomY = Random.Range(_range.bounds.min.y, _range.bounds.max.y);
        //    prefab.transform.position = new Vector2(randomX, randomY);
        //    prefab.GetComponent<Movement>().Run(_range);
        //    m_gameManager.PlusCount();
        //    m_curTime = 0;
        //}
    }
}
