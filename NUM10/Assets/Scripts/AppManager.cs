using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AppManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TargetField;

    [SerializeField]
    private TextMeshProUGUI m_ResultField;

    [SerializeField]
    private Button m_ResetButton;

    [SerializeField]
    private OperatorButton m_SumButton;

    [SerializeField]
    private OperatorButton m_DivButton;

    [SerializeField]
    private OperatorButton m_MulButton;

    [SerializeField]
    private OperatorButton m_SubButton;

    [SerializeField]
    private NumberButton m_Num1Button;

    [SerializeField]
    private NumberButton m_Num2Button;

    [SerializeField]
    private NumberButton m_Num3Button;

    [SerializeField]
    private NumberButton m_Num4Button;

    private List<int> m_TestTaskList = new List<int>();

    
    private void Start()
    {
        
        
        m_TestTaskList.Add(Random.Range(1, 10));
        m_TestTaskList.Add(Random.Range(1, 10));
        m_TestTaskList.Add(Random.Range(1, 10));
        m_TestTaskList.Add(Random.Range(1, 10));
        
        m_SumButton.SetContent(Operator.Sum,OnOperatorButtonClick);
        m_SubButton.SetContent(Operator.Sub,OnOperatorButtonClick);
        m_DivButton.SetContent(Operator.Div,OnOperatorButtonClick);
        m_MulButton.SetContent(Operator.Mul,OnOperatorButtonClick);


        m_ResetButton.onClick.AddListener(OnResetButtonClick);
        
        m_Num1Button.SetValue(m_TestTaskList[0],OnNumberButtonClick);
        m_Num2Button.SetValue(m_TestTaskList[1],OnNumberButtonClick);
        m_Num3Button.SetValue(m_TestTaskList[2],OnNumberButtonClick);
        m_Num4Button.SetValue(m_TestTaskList[3],OnNumberButtonClick);


        }

    private void OnNumberButtonClick(int obj)
    {
        Debug.Log($"Number {obj} is pressed");
    }

    private void OnOperatorButtonClick(Operator obj)
    {
        Debug.Log(obj.ToString()); 
    }

    
    
    
    
    

    
    

    private void OnResetButtonClick()
    {
        Debug.Log("reset level");
    }
}