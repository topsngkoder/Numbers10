using System;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton: MonoBehaviour
{
    private int m_Number;

    [SerializeField]
    private Button m_Button;

    private Action<int> m_OnClickEvent;

    private void Awake()
    {
        m_Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        m_OnClickEvent.Invoke(m_Number);
    }

    public void SetValue(int value, Action<int> onClick)
    {
        m_Number = value;
        m_OnClickEvent = onClick;
    }
    
    



}