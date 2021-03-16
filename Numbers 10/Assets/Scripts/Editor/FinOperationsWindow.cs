using System.Collections.Generic;
using System.Linq;
using LogicDenisKo;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    
    public  class FinOperationsWindow:EditorWindow
    {
        public int[] m_Numbers = new  int[0];
        public Operator[] m_Operators = new Operator[0];
        private List<LogicDenisKo.Solution> m_Solutions = new List<LogicDenisKo.Solution>();
        private Vector2 m_ScrollPos;
      
        [MenuItem("Debug/Windows/Find all operations")]
        static void Init()
        {
            var window = GetWindow(typeof(FinOperationsWindow),false,"Find all operations");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField("Settings");
            EditorGUILayout.BeginHorizontal();
            
            
            var so = new SerializedObject(this);
            
            var numbersProp = so.FindProperty("m_Numbers");
            EditorGUILayout.PropertyField(numbersProp, true);
            
            var operatorsProp = so.FindProperty("m_Operators");
            EditorGUILayout.PropertyField(operatorsProp, true);
            
            so.ApplyModifiedProperties();

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Find"))
            {
                var finder = new SolutionsFinder();
                m_Solutions = finder.FindAllSolutions(m_Numbers.ToList(), m_Operators.ToList());
            }

            m_ScrollPos = EditorGUILayout.BeginScrollView(m_ScrollPos);
            foreach (var solution in m_Solutions)
            {
                EditorGUILayout.LabelField(solution.ToString());
            }
            EditorGUILayout.EndScrollView();
            
            EditorGUILayout.EndVertical();
        }
    }
}