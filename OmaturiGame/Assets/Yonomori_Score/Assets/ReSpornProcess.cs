using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpornProcess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReSporn()
    {
        //  �X�^�[�g�n�_�ɖ߂�
        Transform myTransform = this.transform;         //transform���擾

        Vector3 pos = myTransform.position;             //���W���擾
        Debug.Log("�S�[��");                    //�S�[���ƕ\��
        pos.x = 0f;                                 //x�����ʒu
        pos.y = -3.6f;                              //y�����ʒu
        pos.z = 0f;                                  //z�����ʒu

        myTransform.position = pos;                     //���W��ݒ�
    }
}
