using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    private ILevelsView m_LevelsView;

    private ICalcView m_CalcView;

    [SerializeField]
    private Button m_ResetButton;

    [SerializeField]
    private Button m_SumButton;

    [SerializeField]
    private Button m_DivButton;

    [SerializeField]
    private Button m_MulButton;

    [SerializeField]
    private Button m_SubButton;

    [SerializeField]
    private Button m_Num1Button;

    [SerializeField]
    private Button m_Num2Button;

    [SerializeField]
    private Button m_Num3Button;

    [SerializeField]
    private Button m_Num4Button;


    private void Start()
    {
        m_ResetButton.onClick.AddListener(OnResetButtonClick);
        m_SumButton.onClick.AddListener(OnSumButtonClick);
        m_DivButton.onClick.AddListener(OnDivButtonClick);
        m_MulButton.onClick.AddListener(OnMulButtonClick);
        m_SubButton.onClick.AddListener(OnSubButtonClick);
        m_Num1Button.onClick.AddListener(OnNum1ButtonClick);
        m_Num2Button.onClick.AddListener(OnNum2ButtonClick);
        m_Num3Button.onClick.AddListener(OnNum3ButtonClick);
        m_Num4Button.onClick.AddListener(OnNum4ButtonClick);
    }

    private void OnNum4ButtonClick()
    {
        Debug.Log("4");
    }

    private void OnNum3ButtonClick()
    {
        Debug.Log("3");
    }

    private void OnNum2ButtonClick()
    {
        Debug.Log("2");
    }

    private void OnMulButtonClick()
    {
        Debug.Log("*");
    }

    private void OnNum1ButtonClick()
    {
        Debug.Log("1");
    }

    private void OnSubButtonClick()
    {
        Debug.Log("-");
    }

    private void OnDivButtonClick()
    {
        Debug.Log("/");
    }

    private void OnSumButtonClick()
    {
        Debug.Log("+");
    }

    private void OnResetButtonClick()
    {
        Debug.Log("fuck");
    }
}