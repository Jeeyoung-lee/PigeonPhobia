using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFood : MonoBehaviour
{
    [SerializeField]
    Collider2D _range;
    [SerializeField]
    float m_creationTime;
    [SerializeField]
    GameObject[] _foodPrefab;
    [SerializeField]
    Transform _foodPrefabParent;

    float[] percent = new float[3] { 70f, 20f, 10f };

    float m_originCreationTime;
    float m_time;

    public float CreationTime
    {
        get { return m_creationTime; }
        set { m_creationTime = value; }
    }

    private void Start()
    {
        m_originCreationTime = m_creationTime;
    }

    private void Update()
    {
        Debug.Log(m_creationTime);

        m_time += Time.deltaTime;
        if(m_time > m_creationTime)
        {
            for(int i = 0; i < GetFoodNumber(); i++)
            {
                int index = (int)Choose(percent);
                var prefab = Instantiate(_foodPrefab[index], _foodPrefabParent);
                var randomX = Random.Range(_range.bounds.min.x, _range.bounds.max.x);
                var randomY = Random.Range(_range.bounds.min.y, _range.bounds.max.y);
                prefab.transform.position = new Vector2(randomX, randomY);
                m_time = 0;
            }


        }
    }

    int GetFoodNumber()
    {
        switch(GameManager.instance.Day)
        {
            case 1:
                return 3;
            case 2:
                return 6;
            default:
                return 7;
        }
    }

    float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    public void InitTime()
    {
        m_creationTime = m_originCreationTime;
    }
}
