using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)               //�Փ˂����I�u�W�F�N�g�̃^�O��collision�ɑ��
    {
        Debug.Log(collision.gameObject.name);              //�Փ˂����I�u�W�F�N�g�̖��O��\��

        if (collision.CompareTag("coin"))            //�Փ˂����I�u�W�F�N�g�̃^�O��coin�Ȃ�
        {
            Debug.Log("�Q�b�g");                       //�Q�b�g�ƕ\��
            Destroy(collision.gameObject);          //�Փ˂����R�C��������
        }




    }
}