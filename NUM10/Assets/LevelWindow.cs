using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWindow : MonoBehaviour
{
    [SerializeField]
    private AppManager m_appManager;


    public void LoadLevel(List<int> taskList, int target)
    {
        m_appManager.LevelStart(taskList);
    }
}
