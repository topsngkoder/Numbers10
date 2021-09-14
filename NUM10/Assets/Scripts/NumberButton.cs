using System;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton: MonoBehaviour
{
    private int m_Number;

    [SerializeField]
    private Button m_Button;

    private Action<int,Button> m_OnClickEvent;

    private void Awake()
    {
        m_Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        m_OnClickEvent.Invoke(m_Number, m_Button);
        
    }

    public void SetValue(int value, Action<int, Button> onClick)
    {
        m_Number = value;
        m_OnClickEvent = onClick;
        m_Button.GetComponentInChildren<Text>().text = value.ToString();
    }

    public void Deactivate()
    {
        m_Button.interactable = false;
        m_Button.gameObject.SetActive(false);       
    }
    
    public void Activate()
    {
        m_Button.interactable = true;
        m_Button.gameObject.SetActive(true);
    }
    
    



}
