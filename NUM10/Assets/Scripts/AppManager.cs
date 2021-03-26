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
    private SolutionsFinder m_SolutionsFinder = new SolutionsFinder();


    private int? m_Answer;
    private Operator m_CurrentOperator;
    private int m_StepsLeft;

    private const int Target = 10;
    private const int Resolution = 4;

    private List<Operator> opers = new List<Operator>()
    {
        Operator.Div,
        Operator.Mul,
        Operator.Sub,
        Operator.Sub
    };


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

        LevelStart();
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
        m_StepsLeft = Resolution - 1;
    }

    private bool IsItPossible(List<int> numbers)
    {
        var solutions = m_SolutionsFinder.FindAllSolutions(numbers,opers);
        foreach (var elem in solutions)
        {
            if (elem.Result==Target)
            {
                Debug.Log(elem.ToString());
                return true;
            }
            
        }
        return false;

    }

    private void LevelStart()
    {
        m_TestTaskList = GetTaskList(Resolution);


        for (var i = 0; i < m_NumberButtons.Count; i++)
        {
            m_NumberButtons[i].SetValue(m_TestTaskList[i], OnNumberButtonClick);
        }

        if (!IsItPossible(m_TestTaskList))
        {
            Debug.Log("NOT POSSIBLE");
            LevelStart();
        }

        ResetLevel();
    }

    private List<int> GetTaskList(int resolution)
    {
        var taskList = new List<int>();
        for (int i = 0; i < resolution; i++)
        {
            taskList.Add(Random.Range(1, 10));
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
            var operation = new LogicDenisKo.Operation((int) m_Answer, m_CurrentOperator, obj);

            if (operation.GotResult)
            {
                m_Answer = (int) operation.Result;
                m_CurrentOperator = Operator.None;
                m_ResultField.text = m_Answer.ToString();
                button.GetComponentInParent<NumberButton>().Deactivate();
                m_StepsLeft--;
                if (m_StepsLeft > 0)
                    return;
                if (m_Answer == Target)
                {
                    LevelStart();
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