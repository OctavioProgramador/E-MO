using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<OptionButton> m_buttonList = null;
    [SerializeField] public Text m_score = null;
    [SerializeField] private Image m_image = null;

    public void Construtc(Question q, Action<OptionButton> callback)
    {
        m_question.text = q.text;

        if(m_image != null){
            if(q.emoji != null){
                m_image.sprite = q.emoji;
            }
        }

        for (int n = 0; n < m_buttonList.Count; n++)
        {
            m_buttonList[n].Construct(q.options[n], callback);
        }
    }
    
}
