using System.Collections.Generic;
using System.Linq;
using LogicDenisKo;
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

    private List<NumberButton> m_NumberButtons;

    private List<int> m_TestTaskList = new List<int>();

    private readonly SolutionsFinder m_SolutionsFinder = new SolutionsFinder();


    private int? m_Answer;
    private Operator m_CurrentOperator;
    private int m_StepsLeft;

    [SerializeField]
    private int m_Target;

    [SerializeField]
    private int m_Resolution;

    [SerializeField]
    private List<Operator> m_Operators;

    private int m_LevelCounter;
    private List<List<int>> m_AllCombinations = new List<List<int>>();

    private void Start()
    {
        m_NumberButtons = new List<NumberButton>();
        m_NumberButtons.Add(m_Num1Button);
        m_NumberButtons.Add(m_Num2Button);
        m_NumberButtons.Add(m_Num3Button);
        m_NumberButtons.Add(m_Num4Button);

        m_AllCombinations = AllDifferentCombinationsOfNumbers(m_Resolution);
        m_LevelCounter = 0;

        m_SumButton.SetContent(Operator.Sum, OnOperatorButtonClick);
        m_SubButton.SetContent(Operator.Sub, OnOperatorButtonClick);
        m_DivButton.SetContent(Operator.Div, OnOperatorButtonClick);
        m_MulButton.SetContent(Operator.Mul, OnOperatorButtonClick);


        m_ResetButton.onClick.AddListener(OnResetButtonClick);

        LevelStart(GetTaskList(m_LevelCounter));
        //m_LevelCounter++;
    }

    private void ResetLevel()
    {
        foreach (var numberButton in m_NumberButtons)
        {
            numberButton.Activate();
        }

        m_Answer = null;
        m_CurrentOperator = Operator.None;
        m_ResultField.text = "_ _ _ _";
        m_StepsLeft = m_Resolution - 1;
    }

    private bool IsItPossible(List<int> numbers, int target, List<Operator> operators)
    {
        var solutions = m_SolutionsFinder.FindAllSolutions(numbers, operators);

        foreach (var elem in solutions)
        {
            if (elem.Result != target) continue;
            return true;
        }

        return false;
    }

    private void LevelStart(List<int> taskList)
    {
        for (var i = 0; i < m_NumberButtons.Count; i++)
        {
            m_NumberButtons[i].SetValue(taskList[i], OnNumberButtonClick);
        }

        ResetLevel();
    }

    private List<int> GetTaskList(int index)
    {
        var taskList = AllDifferentCombinationsOfNumbers(m_Resolution);

        

        /*if (!IsItPossible(taskList[index], m_Target, m_Operators))
        {
            Debug.Log($"on index = {m_LevelCounter} is NOT POSSIBLE");
            m_LevelCounter++;
            return GetTaskList(m_LevelCounter);
        }
        Debug.Log($"index = {m_LevelCounter}");*/
        return taskList[m_LevelCounter];
    }


    private void OnNumberButtonClick(int obj, Button button)
    {
        if (m_Answer == null && m_CurrentOperator == Operator.None)
        {
            m_Answer = obj;
            m_ResultField.text = m_Answer.ToString();

            foreach (var numberButton in m_NumberButtons)
            {
                numberButton.Activate();
            }

            button.GetComponentInParent<NumberButton>().Deactivate();
           
        }
        else
        {
            var operation = new Operation((int) m_Answer, m_CurrentOperator, obj);

            if (operation.GotResult)
            {
                m_Answer = (int) operation.Result;
                m_CurrentOperator = Operator.None;
                m_ResultField.text = m_Answer.ToString();
                button.GetComponentInParent<NumberButton>().Deactivate();
                m_StepsLeft--;
                if (m_StepsLeft > 0)
                    return;
                if (m_Answer == m_Target)
                {
                    m_LevelCounter++;
                    LevelStart(GetTaskList(m_LevelCounter));
                }
            }
            else
            {
                Debug.Log("ERROR! Деление невозможно.");
            }
        }
    }

    private void OnOperatorButtonClick(Operator obj)
    {
        if (m_Answer == null)
            return;
        m_CurrentOperator = obj;
        m_ResultField.text = m_Answer.ToString() + LogicDenisKo.OperatorToString.ConvertToString(m_CurrentOperator);
    }

    private void OnResetButtonClick()
    {
        ResetLevel();
    }

    List<int> IntToList(int value)
    {
        List<int> result = new List<int>();
        int number = value;
        for (int i = 0; i < value.ToString().Length; i++)
        {
            if (number % 10 == 0)
            {
                return new List<int>();
            }
            result.Add(number % 10);
            number = number / 10;
        }
        return result;
    }

    int ListToInt(List<int> value)
    {
        int result = 0;

        foreach (var item in value)
        {
            result = result * 10 + item;
        }
        return result;
    }

    void Shuffle(List<List<int>> list)
    {  
    int n = list.Count;  
    while (n > 1) {  
        n--;
        int k = Random.Range(0, n - 1);  
        var value = list[k];  
        list[k] = list[n];  
        list[n] = value;  
    }  
}



    List<List<int>> AllDifferentCombinationsOfNumbers(int length)
    {
        int minNumber = 1, maxNumber = 9;

        for (int i = 1; i < length; i++)
        {
            minNumber = minNumber * 10 + 1;
            maxNumber = maxNumber * 10 + 9;
        }

        List<int> combinations = new List<int>();

        for (int i = minNumber; i <= maxNumber; i++)
        {
            if (IntToList(i).Count == length)
            {
                List<int> combination = IntToList(i);
                combination.Sort();

                combinations.Add(ListToInt(combination));

            }

        }

        combinations.Sort();

        var sortedCombinations = combinations.Distinct().ToList();

        var result = new List<List<int>>();
        foreach (var item in sortedCombinations)

        {
            if (IsItPossible(IntToList(item), m_Target, m_Operators))
            {
                result.Add(IntToList(item));
            }
        }
        Shuffle(result);

        
        return result;
    }
    
}