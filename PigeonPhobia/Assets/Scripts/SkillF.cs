using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillF : Skill
{
    [SerializeField]
    GameObject m_skillFPrefab;
    [SerializeField]
    Transform m_skillFParent;
    [SerializeField]
    Sprite m_skillFSprite;
    [SerializeField]
    Transform m_nestParent;

    GameObject m_item;

    private void Start()
    {
        m_camera = Camera.main;
        m_coolTime = 20;
        Init();
    }

    private void Update()
    {
        if (m_item != null)
            Update_MousePosition();

        if (!m_isUseable && m_coolTime >= 0) // 쿨타임 상태라면
        {
            Use();
            m_coolTime -= Time.deltaTime;
            m_remainTime.text = ((int)m_coolTime).ToString();

            if (m_coolTime <= 0)
            {
                Init();
                m_isUseable = true;
                m_coolTime = 20;
            }
        }

    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        var pos = m_camera.ScreenToWorldPoint(mousePos);
        m_item.transform.position = new Vector3(pos.x, pos.y, 1);
    }

    public override void Create()
    {
        m_item = Instantiate(m_skillFPrefab, m_skillFParent);
        GameManager.instance.SetSkillItem(m_item);
    }

    public override GameObject GetItem()
    {
        return m_item;
    }

    public override void SetImage()
    {
        m_skillImage.sprite = m_skillFSprite;
    }

    public void UseSkill()
    {
        var count = 0;
        var list = new List<GameObject>();
        foreach(Transform nest in m_nestParent)
        {
            count++;
            list.Add(nest.gameObject);
        }

        var index = Random.Range(0, list.Count);
        list[index].transform.GetChild(0).gameObject.SetActive(true);
        list[index].GetComponent<Nest>().Creationable = false;
        StartCoroutine(CMove(list[index]));
    }

    IEnumerator CMove(GameObject gameObject)
    {
        while(true)
        {
            gameObject.transform.Translate(Vector2.up * 2 * Time.deltaTime);
            
            if(!CheckCamera(gameObject))
            {
                Destroy(gameObject);
                break;
            }

            yield return null;
        }
    }

    bool CheckCamera(GameObject gameObject)
    {
        var screenPoint = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        return onScreen;
    }
}
