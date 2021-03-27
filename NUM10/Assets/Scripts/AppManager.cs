using System.Collections.Generic;
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


    private void Start()
    {
        m_NumberButtons = new List<NumberButton>();
        m_NumberButtons.Add(m_Num1Button);
        m_NumberButtons.Add(m_Num2Button);
        m_NumberButtons.Add(m_Num3Button);
        m_NumberButtons.Add(m_Num4Button);


        m_SumButton.SetContent(Operator.Sum, OnOperatorButtonClick);
        m_SubButton.SetContent(Operator.Sub, OnOperatorButtonClick);
        m_DivButton.SetContent(Operator.Div, OnOperatorButtonClick);
        m_MulButton.SetContent(Operator.Mul, OnOperatorButtonClick);


        m_ResetButton.onClick.AddListener(OnResetButtonClick);

        LevelStart(GetTaskList());
    }

    private void ResetLevel()
    {
        foreach (var numberButton in m_NumberButtons)
        {
            numberButton.Activate();
        }

        m_Answer = null;
        m_CurrentOperator = Operator.None;
        m_ResultField.text = ".";
        m_StepsLeft = m_Resolution - 1;
    }

    private bool IsItPossible(List<int> numbers, int target, List<Operator> operators)
    {
        var solutions = m_SolutionsFinder.FindAllSolutions(numbers, operators);

        foreach (var elem in solutions)
        {
            if (elem.Result != target) continue;
            //Debug.Log(elem.ToString());
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

    private List<int> GetTaskList()
    {
        var taskList = new List<int>();

        for (int i = 0; i < m_Resolution; i++)
        {
            taskList.Add(Random.Range(1, 10));
        }

        if (!IsItPossible(taskList, m_Target, m_Operators))
        {
            Debug.Log("NOT POSSIBLE");
            return GetTaskList();
        }

        return taskList;
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
                    LevelStart(GetTaskList());
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
}