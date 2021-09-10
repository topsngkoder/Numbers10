using System.Collections;
using UnityEngine;

public partial class LevelSelectWindow : MonoBehaviour
{

    //private LevelData levelData;
    [SerializeField]
    private LevelView m_levelPrefab;
    [SerializeField]
    private Transform m_LevelsPanel;


    public void SetData(LevelData data)
    {
        for (int i = 1; i < data.numbers.Count; i++)
        {
            var levelView = Instantiate(m_levelPrefab, m_LevelsPanel);
            levelView.SetNumbers(data.numbers[i]);
            levelView.SetName(i.ToString());

        }
    }
}
