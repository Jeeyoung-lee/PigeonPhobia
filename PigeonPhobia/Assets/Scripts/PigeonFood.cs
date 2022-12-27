using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFood : MonoBehaviour
{
    [SerializeField]
    Collider2D _range;
    [SerializeField]
    float _duration;
    [SerializeField]
    GameObject[] _foodPrefab;
    [SerializeField]
    Transform _foodPrefabParent;

    float[] percent = new float[3] { 70f, 20f, 10f };

    float m_time;

    private void Update()
    {
        m_time += Time.deltaTime;
        if(m_time > _duration)
        {
            int index = (int)Choose(percent);
            var prefab = Instantiate(_foodPrefab[index], _foodPrefabParent);
            var randomX = Random.Range(_range.bounds.min.x, _range.bounds.max.x);
            var randomY = Random.Range(_range.bounds.min.y, _range.bounds.max.y);
            prefab.transform.position = new Vector2(randomX, randomY);
            m_time = 0;
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
}
