using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float MoveRightLimit;

    [SerializeField]
    float MoveLeftLimit;

    //1�t���[�����Ƃ̈ړ�����
    private float distance = 0.005f;

    //�����ʒu
    private Vector2 defaultPosition = new Vector2(0, -1.5f);

    //�����X�P�[��
    private Vector2 defaultScale = new Vector2(1.5f, 1.5f);

    //�ړ��\���ǂ���
    private bool canMove;

    private void Start()
    {
        //�����ʒu��ݒ�
        transform.position = defaultPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Walk();
        }
    }

    private void Walk()
    {
        //�}�E�X�̈ʒu�����[���h���W�ɕϊ�
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //���E�̈ړ�����
        cursorPos.x = Mathf.Clamp(cursorPos.x, MoveLeftLimit, MoveRightLimit);

        //�ړ�����
        if(transform.position.x < cursorPos.x - distance)
        {
            transform.localScale = new Vector2(defaultScale.x * -1, defaultScale.y);
            transform.position = new Vector2(transform.position.x + distance, transform.position.y);
        }
        else if(cursorPos.x + distance < transform.position.x)
        {
            transform.localScale = new Vector2(defaultScale.x, defaultScale.y);
            transform.position = new Vector2(transform.position.x - distance, transform.position.y);
        }
    }

    /// <summary>
    /// �L�����N�^�[�������ʒu�ɔz�u����
    /// </summary>
    public void SetDefaultPosition()
    {
        transform.position = defaultPosition;
    }

    /// <summary>
    /// �L�����N�^�[���ړ��\�ɂ���
    /// </summary>
    public void AllowMove()
    {
        canMove = true;
    }

    /// <summary>
    /// �L�����N�^�[���ړ��s�ɂ���
    /// </summary>
    public void ForbiddenMove()
    {
        canMove = false;
    }
}
