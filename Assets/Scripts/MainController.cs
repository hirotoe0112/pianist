using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField]
    GameObject childPlayer;

    [SerializeField]
    GameObject adultPlayer;

    [SerializeField]
    Text termText;

    [SerializeField]
    Text dayText;

    [SerializeField]
    Text moneyText;

    [SerializeField]
    Text messageArea;

    [SerializeField]
    MessageItem tutorial;

    [SerializeField]
    GameObject forbiddenOperationArea;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.CurrentTerm == Data.TERM.CHILD)
        {
            player = childPlayer.GetComponent<PlayerController>();
            adultPlayer.SetActive(false);
        }
        else
        {
            player = adultPlayer.GetComponent<PlayerController>();
            childPlayer.SetActive(false);
        }

        //UI�̐ݒ�
        SetUIText();

        //�����������J�n
        StartCoroutine(Init());
    }

    /// <summary>
    /// ��������
    /// </summary>
    /// <returns></returns>
    private IEnumerator Init()
    {
        //�`���[�g���A��
        if (!Data.isTutorialFinished)
        {
            //�I�u�W�F�N�g���N���b�N�s�ɂ���
            forbiddenOperationArea.SetActive(true);

            //�v���C���[���ړ��s�ɂ���
            player.ForbiddenMove();

            //�I����ĂȂ���Ύ��{
            yield return StartCoroutine(Tutorial());

            //�v���C���[���ړ��\�ɂ���
            player.AllowMove();

            //�I�u�W�F�N�g���N���b�N�\�ɂ���
            forbiddenOperationArea.SetActive(false);
        }
        else
        {
            //�v���C���[���ړ��\�ɂ���
            player.AllowMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// UI�̐ݒ�
    /// </summary>
    private void SetUIText()
    {
        //���t
        termText.text = Data.GetTermName(Data.CurrentTerm);
        dayText.text = Data.CurrentDate.ToString();
        //������
        moneyText.text = GlobalProc.AddComma(Data.Money);
    }

    /// <summary>
    /// �`���[�g���A��
    /// </summary>
    /// <returns></returns>
    private IEnumerator Tutorial()
    {
        //�����E�G�C�g
        yield return new WaitForSecondsRealtime(1.0f);

        //���b�Z�[�W�\��
        var message = new Message();
        yield return StartCoroutine(message.DrawMessage(tutorial.GetMessages(), messageArea));

        //�`���[�g���A���ς�
        Data.isTutorialFinished = true;
    }
}
