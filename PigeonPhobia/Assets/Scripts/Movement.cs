using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Collider2D m_range;
    [SerializeField]
    float _speed;
    [SerializeField]
    float _duration;

    private void Start()
    {

    }

    public void Run(Collider2D _range)
    {
        m_range = _range;
        StartCoroutine(CRun(transform));
    }

    public IEnumerator CRun(Transform transform)
    {
        while (true)
        {
            var elapsed = 0f;

            var randomX = Random.Range(m_range.bounds.min.x, m_range.bounds.max.x);
            var randomY = Random.Range(m_range.bounds.min.y, m_range.bounds.max.y);

            while (_duration > elapsed)
            {
                elapsed += Time.deltaTime;
                transform.Translate(new Vector2(randomX, randomY).normalized * _speed * Time.deltaTime);

                Vector2 position = transform.position;
                position.x = Mathf.Clamp(position.x, m_range.bounds.min.x, m_range.bounds.max.x);
                position.y = Mathf.Clamp(position.y, m_range.bounds.min.y, m_range.bounds.max.y);
                transform.position = position;

                if (position.y <= m_range.bounds.min.y || position.y >= m_range.bounds.max.y) // ÀçÅ½»ö
                    break;

                if (position.x <= m_range.bounds.min.x || position.x >= m_range.bounds.max.x) // ÀçÅ½»ö
                    break;

                yield return null;
            }

            yield return null;
        }
    }
}
