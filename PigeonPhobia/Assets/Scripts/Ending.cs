using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ending : MonoBehaviour
{
    [SerializeField]
    Text m_title;
    [SerializeField]
    Image m_image;
    [SerializeField]
    Sprite[] m_endingSprits;
    [SerializeField]
    Text m_story;

    public void Show(int _number)
    {
        if(_number == 0)
        {
            GoodEnding();
        }
        else if(_number == 1)
        {
            NormalEnding();
        }
        else
        {
            BadEnding();
        }
    }

    void GoodEnding()
    {
        m_title.text = "������ ����";
        m_image.sprite = m_endingSprits[0];
        m_story.text = "���� ������ �����Դϴ�!" + Environment.NewLine + "�� ������ �̻���¸� ȥ���� ������ �̰ܳ¾��!" + Environment.NewLine + "�����ϰ� ������ �� ����� ������." + Environment.NewLine + "������ ������ �η��� ���̸�, �� �ִ��� ���� ��ſ��� �ֽ��ϴ�.";
    }

    void NormalEnding()
    {
        m_title.text = "�ڶ����� ����";
        m_image.sprite = m_endingSprits[1];
        m_story.text = "����� �����߽��ϴ�!" + Environment.NewLine + "��ѱ��� ħ�����κ��� ������ ���ѳ¾��!" + Environment.NewLine + "��� ��� ��ѱ⸦ ó�������� ��������, �� ������ ����� ������ ���� �̴ϴ�.";
    }

    void BadEnding()
    {
        m_title.text = "��ѱ��� ����";
        m_image.sprite = m_endingSprits[2];
        m_story.text = "��Ÿ���Ե� �η��� �й��߽��ϴ�." + Environment.NewLine + "�� ���ô� �̹� ��ѱ��� ���� �Ǿ�����." + Environment.NewLine + "���� ȸ������ �Ǿ���� ���ÿ� �� �̻� ����� ��ư� ������ �����ϴ�.";
    }
}
