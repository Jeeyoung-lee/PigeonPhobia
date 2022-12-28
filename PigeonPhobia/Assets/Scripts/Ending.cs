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
        m_title.text = "위대한 업적";
        m_image.sprite = m_endingSprits[0];
        m_story.text = "정말 위대한 업적입니다!" + Environment.NewLine + "이 초유의 이상사태를 혼자의 힘으로 이겨냈어요!" + Environment.NewLine + "찬연하게 빛나는 이 모습을 보세요." + Environment.NewLine + "여전히 서울은 인류의 것이며, 그 최대의 공은 당신에게 있습니다.";
    }

    void NormalEnding()
    {
        m_title.text = "자랑스런 성공";
        m_image.sprite = m_endingSprits[1];
        m_story.text = "당신은 성공했습니다!" + Environment.NewLine + "비둘기의 침공으로부터 서울을 지켜냈어요!" + Environment.NewLine + "비록 모든 비둘기를 처리하지는 못했지만, 그 누구도 당신을 비난하지 못할 겁니다.";
    }

    void BadEnding()
    {
        m_title.text = "비둘기의 도시";
        m_image.sprite = m_endingSprits[2];
        m_story.text = "안타깝게도 인류는 패배했습니다." + Environment.NewLine + "이 도시는 이미 비둘기의 것이 되었군요." + Environment.NewLine + "온통 회색빛이 되어버린 도시에 더 이상 사람이 살아갈 구역은 없습니다.";
    }
}
