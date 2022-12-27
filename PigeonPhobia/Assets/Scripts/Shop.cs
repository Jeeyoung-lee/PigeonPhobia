using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField]
    Text m_skillName;
    [SerializeField]
    Text m_skillDescription;
    [SerializeField]
    Button m_buyBtn;
    [SerializeField]
    Button m_nextDayBtn;
    [SerializeField]
    Button[] m_skillItemBtns;

    string m_selectSkillName;
    GameObject m_selectSkill;

    private void OnEnable()
    {
        Init();
    }

    private void Start()
    {
        m_buyBtn.onClick.AddListener(() => Buy());
        m_nextDayBtn.onClick.AddListener(() => NextDay());
    }

    void Init()
    {

    }

    public void Select(string _skillName)
    {
        switch(_skillName)
        {
            case "A":

                if(FindObjectOfType<SkillA>().Possession)
                {
                    m_buyBtn.GetComponentInChildren<Text>().text = "���� �Ϸ�";
                    m_buyBtn.interactable = false;
                }
                else
                {
                    m_buyBtn.GetComponentInChildren<Text>().text = "���� �ϱ�";
                    m_buyBtn.interactable = true;
                }

                m_selectSkillName = _skillName;
                m_skillName.text = "��ä �ֵθ���";
                m_skillDescription.text = "��ä�� �ֵѷ� ��ѱ⸦ ������ �ѾƳ��ϴ�";
                m_selectSkill = EventSystem.current.currentSelectedGameObject;
                break;
            case "S":

                if (FindObjectOfType<SkillS>().Possession)
                {
                    m_buyBtn.GetComponentInChildren<Text>().text = "���� �Ϸ�";
                    m_buyBtn.interactable = false;
                }
                else
                {
                    m_buyBtn.GetComponentInChildren<Text>().text = "���� �ϱ�";
                    m_buyBtn.interactable = true;
                }

                m_selectSkillName = _skillName;
                m_skillName.text = "�׹� ������";
                m_skillDescription.text = "�׹��� ��ȹ�� ��ѱ�� ��� ������ϴ�";
                m_selectSkill = EventSystem.current.currentSelectedGameObject;
                break;
            case "":
                m_selectSkillName = string.Empty;
                m_skillName.text = "�غ���";
                m_skillDescription.text = "�غ���";
                m_selectSkill = null;
                break;
        }
    }

    void Buy()
    {
        if (m_selectSkill == null || string.IsNullOrEmpty(m_selectSkillName))
            return;

        switch (m_selectSkillName)
        {
            case "A":
                FindObjectOfType<SkillA>().Possession = true;
                m_buyBtn.GetComponentInChildren<Text>().text = "���� �Ϸ�";
                m_buyBtn.interactable = false;
                break;
            case "S":
                FindObjectOfType<SkillS>().Possession = true;
                m_buyBtn.GetComponentInChildren<Text>().text = "���� �Ϸ�";
                m_buyBtn.interactable = false;
                break;

        }
    }

    void NextDay()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
