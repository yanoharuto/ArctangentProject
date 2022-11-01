using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour
{
    // �_�ł�����Ώ�
    [SerializeField] public Renderer _target;
    // �_�Ŏ���[s]
    [SerializeField] private float _cycle = 1;

    private float _time;

    private void Update()
    {
        // �����������o�߂�����
        _time += Time.deltaTime;

        // ����cycle�ŌJ��Ԃ��l�̎擾
        // 0�`cycle�͈̔͂̒l��������
        var repeatValue = Mathf.Repeat(_time, _cycle);

        // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
        _target.enabled = repeatValue >= _cycle * 0.5f;
    }
}
