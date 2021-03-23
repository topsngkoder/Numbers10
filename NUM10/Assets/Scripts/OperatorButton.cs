using System;
using UnityEngine;
using UnityEngine.UI;

public class OperatorButton: MonoBehaviour
{
    [SerializeField]
    private Button m_Button;

    private Operator m_Operator;
    
    private Action<Operator> m_OnClickEvent;

    private void Awake()
    {
        m_Button.onClick.AddListener(OnClick);
           
    }

    private void OnClick()
    {
        m_OnClickEvent.Invoke(m_Operator);
    }

    public void SetContent(Operator oper, Action<Operator> onClick)
    {
        m_Operator = oper;
        m_OnClickEvent = onClick;
    }
}