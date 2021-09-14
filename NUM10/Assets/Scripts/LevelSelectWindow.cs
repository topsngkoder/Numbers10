using System.Collections;
using System;
using UnityEngine;

public partial class LevelSelectWindow : MonoBehaviour
{

    [SerializeField]
    private LevelView m_levelPrefab;
    [SerializeField]
    private Transform m_LevelsPanel;


    public struct Data
    {
        public string Name;
        public int index;
        public Action<int> OnClick;
    }


    public void SetData(LevelData data)
    {
        for (int i = 1; i < data.Levels.Count; i++)
        {
            var levelView = Instantiate(m_levelPrefab, m_LevelsPanel);

            levelView.SetData(data.Levels[i]);
            
        }
        
    }

    
}
