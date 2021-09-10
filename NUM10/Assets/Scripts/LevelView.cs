using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelView: MonoBehaviour
{
    private List<int> m_numbers;
    private string m_name;
    [SerializeField]
    private Text text;

    


    public void SetNumbers(List<int> data)
    {
        m_numbers = data;
    }

    public void SetName(string data)
    {
        text.text = data;
        
    }

}