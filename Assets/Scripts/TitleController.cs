using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        //�Z�[�u�f�[�^�����݂���ꍇ�݂̂Â�����{�^����L���ɂ��� 
        if (Save.IsExistData())
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �͂��߂���
    /// </summary>
    public void StartNew()
    {
        SceneManager.LoadScene("IntroScene");
    }

    /// <summary>
    /// �Â�����
    /// </summary>
    public void StartContinue()
    {
        //�Z�[�u�f�[�^�����[�h
        Save.LoadGame();
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// ���p�[�g���[
    /// </summary>
    public void Repertoire()
    {
        Debug.Log("���p�[�g���[");
    }
}
