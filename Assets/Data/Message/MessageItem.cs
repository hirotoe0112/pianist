using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MessageItem : ScriptableObject
{
    [SerializeField]
    [Multiline(5)]
    List<string> messages = new List<string>();

    public List<string> GetMessages()
    {
        return messages;
    }
}
