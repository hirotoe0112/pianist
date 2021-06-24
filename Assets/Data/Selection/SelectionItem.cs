using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectionItem : ScriptableObject
{
    [SerializeField]
    List<SelectionData> selections = new List<SelectionData>();

    public List<SelectionData> GetSelections()
    {
        return selections;
    }
}

[System.Serializable]
public class SelectionData
{
    [SerializeField]
    public int Id;
    [SerializeField]
    public string Text;
}
