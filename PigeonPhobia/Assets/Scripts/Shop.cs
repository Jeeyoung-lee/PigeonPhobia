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
    Text m_targetText;
    [SerializeField]
    Text m_skillInfoText;

    [SerializeField]
    Button m_buyBtn;

    [SerializeField]
    Button[] m_skillItemBtns;

    [SerializeField]
    Text m_dayText;

    [SerializeField]
    Image m_newPigeonImage;
    [SerializeField]
    Sprite[] m_newPigeonSprits;

    [SerializeField]
    Image m_newSkillImage;
    [SerializeField]
    Sprite[] m_newSkillSprits;

    string m_selectSkillName;
    GameObject m_selectSkill;


    int m_day;

    private void OnEnable()
    {
        Init();
        SoundManager.instance.PlayShopSound();
    }

    private void Start()
    {
        m_buyBtn.onClick.AddListener(() => Buy());
        //m_nextDayBtn.onClick.AddListener(() => NextDay());
    }

    void Init()
    {
        m_day = GameManager.instance.Day;

        switch (m_day)
        {
            case 1:
                m_newPigeonImage.sprite = m_newPigeonSprits[0];
                m_newSkillImage.sprite = m_newSkillSprits[0];
                m_skillName.text = "��ä �ֵθ���";
                m_skillDescription.text = "��ä�� �ֵѷ� ��ѱ⸦ ��� �ѾƳ��ϴ�";
                m_targetText.text = "��� : " + "��ѱ� 1��ü";
                m_skillInfoText.text = "A ��ư�� ���� ��� ����";
                m_dayText.text = "2������"; 
                break;
            case 2:
                m_newPigeonImage.sprite = m_newPigeonSprits[1];
                m_newSkillImage.sprite = m_newSkillSprits[1];
                m_skillName.text = "�׹� ������";
                m_skillDescription.text = "�׹��� ��ȹ�� ��ѱ�� ��� ������ϴ�";
                m_targetText.text = "��� : " + "��ȹ�� ��ѱ� ����";
                m_skillInfoText.text = "S ��ư�� ���� ��� ����";
                m_dayText.text = "3������";
                break;
            case 3:
                m_newPigeonImage.sprite = m_newPigeonSprits[2];
                m_newSkillImage.sprite = m_newSkillSprits[2];
                m_skillName.text = "��ѱ� ��";
                m_skillDescription.text = "��ѱ⿡�� ���ظ� �ִ� ���� �����մϴ�";
                m_targetText.text = "��� : " + "���� ���� ��ѱ�";
                m_skillInfoText.text = "D ��ư�� ���� ��� ����";
                m_dayText.text = "4������";
                break;
            case 4:
                m_newSkillImage.sprite = m_newSkillSprits[3];
                m_skillName.text = "ũ���� �θ���";
                m_skillDescription.text = "���� �ϳ��� �������� ��� ö���մϴ�";
                m_targetText.text = "��� : " + "����";
                m_skillInfoText.text = "F ��ư�� ���� ��� ����";
                m_dayText.text = "��������";
                break;
        }
    }

    public void Select(string _skillName)
    {
        //switch(_skillName)
        //{
        //    case "A":

        //        if(FindObjectOfType<SkillA>().Possession)
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �Ϸ�";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �ϱ�";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "��ä �ֵθ���";
        //        m_skillDescription.text = "��ä�� �ֵѷ� ��ѱ⸦ ������ �ѾƳ��ϴ�";
        //        m_selectSkill = EventSystem.current.currentSelectedGameObject;
        //        break;
        //    case "S":

        //        if(m_day <= 1)
        //        {
        //            m_buyBtn.interactable = false;
        //            return;
        //        }

        //        if (FindObjectOfType<SkillS>().Possession)
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �Ϸ�";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �ϱ�";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "�׹� ������";
        //        m_skillDescription.text = "�׹��� ��ȹ�� ��ѱ�� ��� ������ϴ�";
        //        m_selectSkill = EventSystem.current.currentSelectedGameObject;
        //        break;
        //    case "D":

        //        if (m_day <= 2)
        //        {
        //            m_buyBtn.interactable = false;
        //            return;
        //        }

        //        if (FindObjectOfType<SkillD>().Possession)
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �Ϸ�";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �ϱ�";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "��ѱ� ��";
        //        m_skillDescription.text = "��ѱ⿡�� ���ظ� �ִ� ���� �����մϴ�";
        //        m_selectSkill = EventSystem.current.currentSelectedGameObject;
        //        break;
        //    case "F":

        //        if (m_day <= 3)
        //        {
        //            m_buyBtn.interactable = false;
        //            return;
        //        }

        //        if (FindObjectOfType<SkillF>().Possession)
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �Ϸ�";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "ȹ�� �ϱ�";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "ũ���� �θ���";
        //        m_skillDescription.text = "���� �ϳ��� ��� ö���մϴ�";
        //        m_selectSkill = EventSystem.current.currentSelectedGameObject;
        //        break;
        //}
    }

    void Buy()
    {
        switch (m_day)
        {
            case 1:
                FindObjectOfType<SkillA>().Possession = true;
                NextDay();
                break;
            case 2:
                FindObjectOfType<SkillS>().Possession = true;
                NextDay();
                break;
            case 3:
                FindObjectOfType<SkillD>().Possession = true;
                NextDay();
                break;
            case 4:
                FindObjectOfType<SkillF>().Possession = true;
                NextDay();
                break;
        }
    }

    void NextDay()
    {
        FindObjectOfType<FadeInOut>().FadeIn();
        gameObject.SetActive(false);
        GameManager.instance.isStart = true;
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        SoundManager.instance.PlayGameSound();
    }
}
