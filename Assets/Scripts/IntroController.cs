using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [SerializeField]
    Text messageArea;

    [SerializeField]
    MessageItem message1;

    [SerializeField]
    MessageItem message2;

    [SerializeField]
    MessageItem message3;

    [SerializeField]
    SelectionItem selectionItem;

    [SerializeField]
    GameObject selectionArea;

    [SerializeField]
    GameObject pianist;

    [SerializeField]
    GameObject fadeOutImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroProgress());
    }

    private IEnumerator IntroProgress()
    {
        //�����E�G�C�g
        yield return new WaitForSecondsRealtime(1.0f);

        //���b�Z�[�W�\��
        var message = new Message();
        yield return StartCoroutine(message.DrawMessage(message1.GetMessages(), messageArea));

        //�s�A�j�X�g�摜���t�F�[�h�C���\��
        StartCoroutine(FadeInImage());

        //���b�Z�[�W�\��
        yield return StartCoroutine(message.DrawMessage(message2.GetMessages(), messageArea));

        //�I�����\��
        var selection = new Selection();
        int? selectionId = null;
        yield return StartCoroutine(selection.WaitSelection(selectionItem.GetSelections(), selectionArea, (r => selectionId = r)));

        //���b�Z�[�W�\��
        yield return StartCoroutine(message.DrawMessage(message3.GetMessages(), messageArea));

        //�����l���f�[�^�N���X�ɃZ�b�g
        Data.InitData();
        Data.CurrentTerm = Data.TERM.CHILD;
        Data.CurrentDate = 1;
        Data.Money = 0;

        //�t�F�[�h�A�E�g
        yield return StartCoroutine(FadeOutDisplay());

        //���C���V�[���֑J��
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// �摜�̃t�F�[�h�C���\��
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeInImage()
    {
        float alpha = 0;
        SpriteRenderer renderer = pianist.GetComponent<SpriteRenderer>();
        Color renderColor = renderer.color;
        while(alpha < 1)
        {
            renderColor.a = alpha;
            renderer.color = renderColor;
            alpha += 0.0004f;
            yield return null;
        }
    }

    /// <summary>
    /// ��ʂ̃t�F�[�h�A�E�g
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOutDisplay()
    {
        fadeOutImage.SetActive(true);
        float alpha = 0;
        Image image = fadeOutImage.GetComponent<Image>();
        Color imageColor = image.color;
        while(alpha < 1)
        {
            imageColor.a = alpha;
            image.color = imageColor;
            alpha += 0.001f;
            yield return null;
        }
    }
}
