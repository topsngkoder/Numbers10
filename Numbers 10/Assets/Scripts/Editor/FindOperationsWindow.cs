using System.Collections.Generic;
using System.Linq;
using LogicDenisKo;
using Specifications;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class FindOperationsWindow : EditorWindow
    {
        public int[] m_Numbers = new int[0];
        public Operator[] m_Operators = new Operator[0];
        private List<LogicDenisKo.Solution> m_Solutions = new List<LogicDenisKo.Solution>();
        
        private Vector2 m_SolutionsScrollPos;
        private Vector2 m_FiltersScrollPos;
        
        private bool m_ResultFilterToggle;
        private bool m_ExcludeErrorToggle;
        
        private SerializedObject m_SerializedObject;
        private int m_OperatorFilterInput;
        private Filter<LogicDenisKo.Solution> m_Filter = new Filter<LogicDenisKo.Solution>();
        private List<ISpecification<LogicDenisKo.Solution>> m_Specifications = new List<ISpecification<LogicDenisKo.Solution>>();

        [MenuItem("Debug/Windows/Find all operations")]
        static void Init()
        {
            var window = GetWindow(typeof(FindOperationsWindow), false, "Find all operations");
            window.Show();
        }

        private List<Operator> m_Previous = new List<Operator>();
        private void OnGUI()
        {
            m_SerializedObject = new SerializedObject(this);
            m_Specifications.Clear();
          
            EditorGUILayout.BeginVertical("Box");
            DrawSettingsLabel();
            EditorGUILayout.BeginHorizontal("Box");

            DrawNumbersArray();
            DrawOperatorsArray();
            ApplyModifiedProperties();


            EditorGUILayout.EndHorizontal();

            DrawFindButton();
            
            EditorGUILayout.BeginHorizontal("Box");

            m_FiltersScrollPos = EditorGUILayout.BeginScrollView(m_FiltersScrollPos);
            EditorGUILayout.BeginVertical("Box",GUILayout.Width(250));
            m_ResultFilterToggle = EditorGUILayout.Toggle("Result Filter",m_ResultFilterToggle);
            if (m_ResultFilterToggle)
            {
                m_OperatorFilterInput = EditorGUILayout.IntField("Target",m_OperatorFilterInput);
                m_Specifications.Add(new SolutionResultSpec(m_OperatorFilterInput));
            }
            m_ExcludeErrorToggle = EditorGUILayout.Toggle("Exclude Error Filter",m_ExcludeErrorToggle);
            if (m_ExcludeErrorToggle)
            {
                m_Specifications.Add(new SolutionExcludeErrorSpec());
            }
            
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
            
            DrawSolutionsArray();
            
            
            
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        #region Draw

        private void DrawSolutionsArray()
        {
            EditorGUILayout.BeginVertical("Box");
            m_SolutionsScrollPos = EditorGUILayout.BeginScrollView(m_SolutionsScrollPos);
            var filtered = m_Filter.Find(m_Solutions, m_Specifications.ToArray());
            foreach (var solution in filtered)
                EditorGUILayout.LabelField(solution.ToString());
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }

        private void DrawFindButton()
        {
            if (GUILayout.Button("Find"))
                Find();
            
        }

        private void Find()
        {
            var finder = new SolutionsFinder();
            m_Solutions = finder.FindAllSolutions(m_Numbers.ToList(), m_Operators.ToList());
        }

        private void ApplyModifiedProperties()
        {
            m_SerializedObject.ApplyModifiedProperties();
        }

        private void DrawOperatorsArray()
        {
            var operatorsProp = m_SerializedObject.FindProperty("m_Operators");
            
            EditorGUILayout.PropertyField(operatorsProp, true);
        }

        private void DrawNumbersArray()
        {
            var numbersProp = m_SerializedObject.FindProperty("m_Numbers");
            EditorGUILayout.PropertyField(numbersProp, true);
        }

        private static void DrawSettingsLabel()
        {
            EditorGUILayout.LabelField("Settings");
        }

        #endregion
    }
}