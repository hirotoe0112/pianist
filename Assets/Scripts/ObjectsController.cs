using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{
    [SerializeField]
    GameObject forbiddenOperationArea;

    [SerializeField]
    Text messageArea;

    [SerializeField]
    MessageItem exitMessage;

    [SerializeField]
    MessageItem pianoMessage;

    private Message message = new Message();

    /// <summary>
    /// ���p�[�g���[�{�^���N���b�N������
    /// </summary>
    public void OnClickRepertoire()
    {
        Debug.Log("repa-tori-");
    }

    /// <summary>
    /// �Z�[�u�{�^���N���b�N������
    /// </summary>
    public void OnClickSave()
    {
        Debug.Log("save");
    }

    /// <summary>
    /// �h�A�N���b�N������
    /// </summary>
    public void OnClickDoor()
    {
        //�h�A�N���b�N�ڍ׏��������s
        StartCoroutine(OnClickDoorDetail());
    }

    /// <summary>
    /// �h�A�N���b�N�ڍ׏���
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnClickDoorDetail()
    {
        //���̃{�^���������s�ɂ���
        forbiddenOperationArea.SetActive(true);
        yield return StartCoroutine(DisplayMessage(exitMessage));
        //���̃{�^���������\�ɂ���
        forbiddenOperationArea.SetActive(false);
    }

    /// <summary>
    /// PC�N���b�N������
    /// </summary>
    public void OnClickPC()
    {
        Debug.Log("pcclick");
    }

    /// <summary>
    /// �J�����_�[�N���b�N������
    /// </summary>
    public void OnClickCalender()
    {
        Debug.Log("karenda-");
    }

    /// <summary>
    /// �s�A�m�N���b�N������
    /// </summary>
    public void OnClickPiano()
    {
        Debug.Log("piano");
    }

    /// <summary>
    /// ���b�Z�[�W�\������
    /// </summary>
    /// <param name="messageItem"></param>
    /// <returns></returns>
    private IEnumerator DisplayMessage(MessageItem messageItem)
    {
        yield return StartCoroutine(message.DrawMessage(messageItem.GetMessages(), messageArea));
    }
}
