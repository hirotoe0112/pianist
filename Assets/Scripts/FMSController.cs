using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSController : MonoBehaviour
{
    [SerializeField]
    GameObject forbiddenOperationArea;

    [SerializeField]
    GameObject FMSArea;

    /// <summary>
    /// �~�{�^���N���b�N������
    /// </summary>
    public void OnClickCloseButton()
    {
        //���C��UI�̃{�^���������\�ɂ���
        forbiddenOperationArea.SetActive(false);

        //FMS���I��
        FMSArea.SetActive(false);
    }
}
