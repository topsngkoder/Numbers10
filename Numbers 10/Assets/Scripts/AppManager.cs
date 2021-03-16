using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    private ILevelsView _levelsView;

    private ICalcView _calcView;

    [SerializeField] private Button resetButton;
    [SerializeField] private Button sumButton;
    [SerializeField] private Button divButton;
    [SerializeField] private Button mulButton;
    [SerializeField] private Button subButton;
    [SerializeField] private Button num1Button;
    [SerializeField] private Button num2Button;
    [SerializeField] private Button num3Button;
    [SerializeField] private Button num4Button;


    private void Start()
    {
       resetButton.onClick.AddListener(OnResetButtonClick);
       sumButton.onClick.AddListener(OnSumButtonClick);
       divButton.onClick.AddListener(OnDivButtonClick);
       mulButton.onClick.AddListener(OnMulButtonClick);
       subButton.onClick.AddListener(OnSubButtonClick);
       num1Button.onClick.AddListener(OnNum1ButtonClick);
       num2Button.onClick.AddListener(OnNum2ButtonClick);
       num3Button.onClick.AddListener(OnNum3ButtonClick);
       num4Button.onClick.AddListener(OnNum4ButtonClick);
       
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