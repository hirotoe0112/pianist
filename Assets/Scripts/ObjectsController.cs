using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ObjectsController : MonoBehaviour
{
    [SerializeField]
    GameObject forbiddenOperationArea;

    [SerializeField]
    GameObject FMSArea;

    [SerializeField]
    Text messageArea;

    [SerializeField]
    GameObject selectionArea;

    [SerializeField]
    MessageItem exitMessage;

    [SerializeField]
    MessageItem pianoMessage;

    [SerializeField]
    MessageItem recitalMessage;

    [SerializeField]
    SelectionItem yesnoSelection;

    [SerializeField]
    SelectionItem exitChildSelection;

    [SerializeField]
    SelectionItem exitAdultSelection;

    private Message message = new Message();
    private Selection selection = new Selection();

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

        //���C������
        yield return StartCoroutine(DisplayMessage(exitMessage.GetMessages()));
        int? result = null;
        yield return StartCoroutine(DisplaySelection(yesnoSelection, (r => result = r)));

        if (result == 1)
        {
            //���̃{�^���������\�ɂ���
            forbiddenOperationArea.SetActive(false);
        }
        else
        {
            //�s����I����
            int? target = null;
            SelectionItem selection = Data.CurrentTerm == Data.TERM.CHILD ? exitChildSelection : exitAdultSelection;
            yield return StartCoroutine(DisplaySelection(selection, (r => target = r)));
            //���̃{�^���������\�ɂ���
            forbiddenOperationArea.SetActive(false);

            //���t���菈��
            //������
        }
    }

    /// <summary>
    /// PC�N���b�N������
    /// </summary>
    public void OnClickPC()
    {
        //���̃{�^���������s�ɂ���
        forbiddenOperationArea.SetActive(true);

        //FMS���J��
        FMSArea.SetActive(true);
    }

    /// <summary>
    /// �J�����_�[�N���b�N������
    /// </summary>
    public void OnClickCalender()
    {
        //�J�����_�[�N���b�N���ڍ׏���
        StartCoroutine(OnClickCalenderDetail());
    }

    /// <summary>
    /// �J�����_�[�N���b�N�ڍ׏���
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnClickCalenderDetail()
    {
        //���̃{�^���������s�ɂ���
        forbiddenOperationArea.SetActive(true);

        int[] recital;
        switch (Data.CurrentTerm)
        {
            case Data.TERM.CHILD:
                recital = GlobalConst.recitalChild;
                break;
            case Data.TERM.STUDENT:
                recital = GlobalConst.recitalStudent;
                break;
            default:
                recital = GlobalConst.recitalAdult;
                break;
        }

        //���߂̔��\��������擾
        var recitalday = recital.Where(i => Data.CurrentDate < i).First();
        var messageList = recitalMessage.GetMessages();
        messageList[0] = string.Format(messageList[0], recitalday);
        yield return StartCoroutine(DisplayMessage(messageList));

        //���̃{�^���������\�ɂ���
        forbiddenOperationArea.SetActive(false);
    }

    /// <summary>
    /// �s�A�m�N���b�N������
    /// </summary>
    public void OnClickPiano()
    {
        //�s�A�m�N���b�N�ڍ׏���
        StartCoroutine(OnClickPianoDetail());
    }
    
    private IEnumerator OnClickPianoDetail()
    {
        //���̃{�^���������s�ɂ���
        forbiddenOperationArea.SetActive(true);

        //���C������
        yield return StartCoroutine(DisplayMessage(pianoMessage.GetMessages()));
        int? result = null;
        yield return StartCoroutine(DisplaySelection(yesnoSelection, (r => result = r)));

        if (result == 1)
        {
            //���̃{�^���������\�ɂ���
            forbiddenOperationArea.SetActive(false);
        }
        else
        {
            //���̃{�^���������\�ɂ���
            forbiddenOperationArea.SetActive(false);

            //���t���菈��
            //������
        }
    }

    /// <summary>
    /// ���b�Z�[�W�\������
    /// </summary>
    /// <param name="messageItem"></param>
    /// <returns></returns>
    private IEnumerator DisplayMessage(IEnumerable messsageList)
    {
        yield return StartCoroutine(message.DrawMessage(messsageList, messageArea));
    }

    /// <summary>
    /// �I��������
    /// </summary>
    /// <param name="selectionItem"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    private IEnumerator DisplaySelection(SelectionItem selectionItem, Action<int?> callback) 
    {
        int? result = null;
        yield return StartCoroutine(selection.WaitSelection(selectionItem.GetSelections(), selectionArea, (r => result = r)));
        callback(result);
    }
}
