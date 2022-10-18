using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clserSystem : MonoBehaviour
{

    Animator animator;
    bool clearFlag;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("clearFlag", clearFlag);
    }

    void OnTriggerEnter2D(Collider2D collision)               //�Փ˂����I�u�W�F�N�g�̃^�O��collision�ɑ��
    {
        Debug.Log(collision.gameObject.name);              //�Փ˂����I�u�W�F�N�g�̖��O��\��

        if (collision.CompareTag("goal"))            //�Փ˂����I�u�W�F�N�g�̃^�O��dangerousObj�Ȃ�
        {
            Debug.Log("�N���A");

            clearFlag = true;
        }
    }
}
