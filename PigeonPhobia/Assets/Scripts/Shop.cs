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
                m_skillName.text = "뜰채 휘두르기";
                m_skillDescription.text = "뜰채를 휘둘러 비둘기를 즉시 쫓아냅니다";
                m_targetText.text = "대상 : " + "비둘기 1개체";
                m_skillInfoText.text = "A 버튼을 눌러 사용 가능";
                m_dayText.text = "2일차로"; 
                break;
            case 2:
                m_newPigeonImage.sprite = m_newPigeonSprits[1];
                m_newSkillImage.sprite = m_newSkillSprits[1];
                m_skillName.text = "그물 던지기";
                m_skillDescription.text = "그물에 포획된 비둘기는 즉시 사라집니다";
                m_targetText.text = "대상 : " + "포획된 비둘기 전부";
                m_skillInfoText.text = "S 버튼을 눌러 사용 가능";
                m_dayText.text = "3일차로";
                break;
            case 3:
                m_newPigeonImage.sprite = m_newPigeonSprits[2];
                m_newSkillImage.sprite = m_newSkillSprits[2];
                m_skillName.text = "비둘기 덫";
                m_skillDescription.text = "비둘기에게 피해를 주는 덫을 생성합니다";
                m_targetText.text = "대상 : " + "덫을 밟은 비둘기";
                m_skillInfoText.text = "D 버튼을 눌러 사용 가능";
                m_dayText.text = "4일차로";
                break;
            case 4:
                m_newSkillImage.sprite = m_newSkillSprits[3];
                m_skillName.text = "크레인 부르기";
                m_skillDescription.text = "둥지 하나를 랜덤으로 즉시 철거합니다";
                m_targetText.text = "대상 : " + "둥지";
                m_skillInfoText.text = "F 버튼을 눌러 사용 가능";
                m_dayText.text = "마지막날";
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
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 완료";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 하기";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "뜰채 휘두르기";
        //        m_skillDescription.text = "뜰채를 휘둘러 비둘기를 빠르게 쫓아냅니다";
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
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 완료";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 하기";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "그물 던지기";
        //        m_skillDescription.text = "그물에 포획된 비둘기는 즉시 사라집니다";
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
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 완료";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 하기";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "비둘기 덫";
        //        m_skillDescription.text = "비둘기에게 피해를 주는 덫을 생성합니다";
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
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 완료";
        //            m_buyBtn.interactable = false;
        //        }
        //        else
        //        {
        //            m_buyBtn.GetComponentInChildren<Text>().text = "획득 하기";
        //            m_buyBtn.interactable = true;
        //        }

        //        m_selectSkillName = _skillName;
        //        m_skillName.text = "크레인 부르기";
        //        m_skillDescription.text = "둥지 하나를 즉시 철거합니다";
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
