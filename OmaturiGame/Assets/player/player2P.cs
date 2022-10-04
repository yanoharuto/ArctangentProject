using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2P : MonoBehaviour
{
    [SerializeField] //playerStatus�̓ǂݍ���
    public playerData playerStatus;//playerData�^��playerStatus������
    Rigidbody2D playerRigidbody; //Rigidbody2D�^�̕ϐ�
    float playerSpeed; //�v���C���[�̑��x
    float playerMaxSpeed; //�v���C���[�̍ő呬�x
    float playerDashSpeed;//�v���C���[�̃_�b�V�����x
    float playerMaxDashSpeed; //�v���C���[�̍ő�_�b�V�����x
    float playerJampPower; //�v���C���[�̃W�����v����傫��
    float playerJampMax; //�v���C���[�̃W�����v�̌��E
    float firstGravityScale; //���߂̏d�̓X�P�[��
    public float Axisx; //GetAxisx�œ���l
    float XMoveCount; //�ǂ�ʍ��E�L�[����������
    float dashChangeCount; //�_�b�V���ɑ���܂ł̎���
    bool rightJampFlag; //�E�ɕǃW�����v�ł���t���O
    bool leftJampFlag;�@//���ɕǃW�����v�ł���t���O
    bool jampFlag; //�W�����v�L�[�����������𔻒�
    bool jampEndFlag; //�W�����v���̏㏸���I���������̔���
    //�A�j���[�V�����֌W-----------------------------------
    Animator animator; //Animator�^�̕ϐ�
    bool walkFlag; //�����Ă��邩�ǂ����̔���
    //-----------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�V�����֌W-----------------------------------
        animator = GetComponent<Animator>(); //animetor�ϐ���Animetor��ǂݍ���
        //------------------------------------
        //�ϐ���playerStatus�̒l��ǂݍ���----------------
        playerSpeed = playerStatus.speed;
        playerMaxSpeed = playerStatus.maxSpeed;
        playerDashSpeed = playerStatus.dashSpeed;
        playerMaxDashSpeed = playerStatus.maxdashSpeed;
        playerJampPower = playerStatus.jumpPower;
        playerJampMax = playerStatus.jumpMax;
        dashChangeCount = playerStatus.dashcount;
        //------------------------------------
        playerRigidbody = GetComponent<Rigidbody2D>(); //Rigidbody2D�̓ǂݍ���
        firstGravityScale = playerRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //�A�j���[�V�����֌W-----------------------------------
        animator.SetBool("walkFlag", walkFlag);
        animator.SetBool("jampFlag", jampFlag);
        animator.SetBool("follFlag", jampFlag);
        animator.SetFloat("velocty.y", playerRigidbody.velocity.y);
        //-----------------------------------------------------
        //�v���C���[�̍��E�ړ�-----------------------------------------
        Axisx = Input.GetAxis("Horizontal2P");
        if (Axisx != 0) //�Q�[���p�b�g�𓮂����Ă����....
        {
            if (playerRigidbody.velocity.x < playerMaxSpeed &&
                playerRigidbody.velocity.x > playerMaxSpeed * -1 &&
                XMoveCount <= dashChangeCount) //���x���ő呬�x�ȉ��œ����������Ԃ����ȉ�����...
            {
                Move();
                walkFlag = true; //�����Ă���t���O
            }
            else if (playerRigidbody.velocity.x < playerMaxDashSpeed &&
                playerRigidbody.velocity.x > playerMaxDashSpeed * -1) //�����������Ԃ����ȏゾ��...
            {
                Move();
            }
            //�U�����---------------------------
            if (Axisx > 0)
            {
                transform.localScale = new Vector3(0.75f, 0.75f, 1); //X�̑傫���𔽓]����B(�U�����)
            }
            else if (Axisx < 0)
            {
                transform.localScale = new Vector3(-0.75f, 0.75f, 1); //X�̑傫���𔽓]����B(�U�����)
            }
            //-----------------------------
        }
        else //�Q�[���p�b�g�𓮂����Ă��Ȃ���...
        {
            walkFlag = false; //�����Ȃ�
            XMoveCount = 0; //�_�b�V���ɕω�������J�E���g�����Z�b�g����
        }
        //-----------------------------------------------------------------------------------
        //�v���C���[�̃W�����v------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            jampFlag = true;
        }
        if (jampFlag == true && jampEndFlag == false)
        {
            Jump();
        }
        //--------------------------------------------------------------------
    }
    public void OnCollisionEnter2D(Collision2D other) //�R���W�����ɓ���������
    {
        if (other.gameObject.CompareTag("scaffold"))
        {
            playerRigidbody.gravityScale = firstGravityScale / 1.25f; //�ǂɓ�����Ɨ������x���x���Ȃ�
            jampFlag = false;
            jampEndFlag = false;
            leftJampFlag = false;
            rightJampFlag = false;
        }
    }
    public void OnCollisionExit2D(Collision2D other) //�R���W�������痣�ꂽ��
    {
        if (other.gameObject.CompareTag("scaffold"))
        {
            playerRigidbody.gravityScale = firstGravityScale;
            if (playerRigidbody.velocity.y < -0.05f) //���x�����ȉ�(������)���ƃW�����v���ł��Ȃ��Ȃ�
            {
                jampFlag = true;
                jampEndFlag = true;
            }
            leftJampFlag = false;
            rightJampFlag = false;
        }
    }
    private void Move() //�v���C���[�̓���
    {
        XMoveCount += 1 * Time.deltaTime;
        playerRigidbody.velocity += new Vector2(playerSpeed * Time.deltaTime * Axisx, 0); //���s
        if (XMoveCount >= dashChangeCount)
        {
            playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * Axisx, 0); //����
        }
    }
    private void Jump() //�v���C���[�̃W�����v
    {
        if (Axisx < 0 && playerRigidbody.velocity.x > -0.1f) //�ǃW�����v(��)
        {
            leftJampFlag = true;
            rightJampFlag = false;
        }
        if (Axisx > 0 && playerRigidbody.velocity.x < 0.1f) //�ǃW�����v(�E)
        {
            rightJampFlag = true;
            leftJampFlag = false;
        }
        if (jampEndFlag == false) //�W�����v���I����Ă��Ȃ���
        {
            playerRigidbody.velocity += new Vector2(0, playerJampPower * Time.deltaTime); //���ʂ̃W�����v
            if (leftJampFlag == true && Axisx != 0)
            {
                playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * 9, 0); //�ǃW�����v(��)
            }
            if (rightJampFlag == true && Axisx != 0)
            {
                playerRigidbody.velocity += new Vector2(-1 * playerDashSpeed * Time.deltaTime * 9, 0); //�ǃW�����v(�E)
            }
            if (playerRigidbody.velocity.y > playerJampMax)
            {
                jampEndFlag = true; //�W�����v���I������t���O
            }

        }
    }
    private void Die() //�v���C���[�̎��S����
    {
        animator.SetTrigger("dieTrigger");
    }
    private void AddScore() //�X�R�A�ǉ�
    {

    }
    private void Hide() //�B��
    {

    }
    void dieanimeend() //���ʃ��[�V�����I���p�C�x���g
    { 
        animator.SetBool("dieFlag", true);
    }

}
