using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelView: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Button button;

    public struct Data
    {
        public string Name;
        public int Index;
        public Action<int> OnClick;
    }

    private Data _data;

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    

    public void SetData(Data data)
    {
        _data = data;
        text.text = _data.Name;
    }

    private void OnClick()
    {
        _data.OnClick.Invoke(_data.Index);
    }
}