using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1P : MonoBehaviour
{
    [SerializeField] //playerStatusの読み込み
    public playerData playerStatus;//playerData型のplayerStatusを入れる
    [SerializeField]
    private InputControllerBase inputGetter;
    [SerializeField]
    private ReSpornProcess m_reSpornProcess;
    Rigidbody2D playerRigidbody; //Rigidbody2D型の変数
    float playerSpeed; //プレイヤーの速度
    float playerMaxSpeed; //プレイヤーの最大速度
    float playerDashSpeed;//プレイヤーのダッシュ速度
    float playerMaxDashSpeed; //プレイヤーの最大ダッシュ速度
    float playerJampPower; //プレイヤーのジャンプする大きさ
    float playerJampMax; //プレイヤーのジャンプの限界
    float firstGravityScale; //初めの重力スケール
    public float Axisx; //GetAxisxで得る値
    float XMoveCount; //どれ位左右キーを押したか
    float dashChangeCount; //ダッシュに代わるまでの時間
    bool rightJampFlag; //右に壁ジャンプできるフラグ
    bool leftJampFlag;　//左に壁ジャンプできるフラグ
    bool jampFlag; //ジャンプキーを押したかを判定
    bool jampEndFlag; //ジャンプ時の上昇が終了したかの判定
    [SerializeField][Header("ジャンプ用SE")] private AudioClip jampSE; //ジャンプの効果音
    [SerializeField][Header("歩き用SE")] private AudioClip DashSE; //ジャンプの効果音
    [SerializeField][Header("歩き用SE頻度")] private float DashSEFrequency;
    [SerializeField][Header("壁キック用エフェクト")] private GameObject wallKickEffect; //壁キックエフェクトのゲームオブジェクト」
    AudioSource audioSource; //AudoSourceを読み込むための変数
    [SerializeField][Header("壁キック用SE")] private AudioClip wallKickSE; //壁キックの効果音
    [Header("=========================-")]
    float wallKickEffectAng; //壁きっくエフェクトの角度
    bool wallKickEffectOutputFlag; //壁キックのエフェクトが出たかどうかのフラグ
    [SerializeField] private SetDeadObj setDeadObj;

    ///追加　 米盛
    public bool dieFlag; //死んだかどうか判定
    bool clearFlag;

    Vector3 scale;
    //アニメーション関係-----------------------------------
    Animator animator; //Animator型の変数
    bool walkFlag; //歩いているかどうかの判定
    //-----------------------------------------------------
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();//AudoSourceを読み込む
        wallKickEffectAng = wallKickEffect.transform.eulerAngles.y; //角度の変数をエフェクトの角度にする
        //アニメーション関係-----------------------------------
        animator = GetComponent<Animator>(); //animetor変数にAnimetorを読み込む
        //------------------------------------
        //変数にplayerStatusの値を読み込む----------------
        playerSpeed = playerStatus.speed;
        playerMaxSpeed = playerStatus.maxSpeed;
        playerDashSpeed = playerStatus.dashSpeed;
        playerMaxDashSpeed = playerStatus.maxdashSpeed;
        playerJampPower = playerStatus.jumpPower;
        playerJampMax = playerStatus.jumpMax;
        dashChangeCount = playerStatus.dashcount;
        //------------------------------------
        playerRigidbody = GetComponent<Rigidbody2D>(); //Rigidbody2Dの読み込み
        firstGravityScale = playerRigidbody.gravityScale;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dieFlag && !clearFlag) 
        {//アニメーション関係-----------------------------------
            animator.SetBool("walkFlag", walkFlag);
            animator.SetBool("jampFlag", jampFlag);
            animator.SetBool("follFlag", jampFlag);
            animator.SetFloat("velocty.y", playerRigidbody.velocity.y);
            //-----------------------------------------------------
            //プレイヤーの左右移動-----------------------------------------
            InputParameter inputParam = inputGetter.GetInputParam();
            Axisx = inputParam.m_LStickHValue;

            //追加 米盛
            clearFlag = animator.GetBool("clearFlag");
            bool dieflag = animator.GetBool("dieflag");

            ///dieflag == false  clearFlag == false 追加　米盛
            if (Axisx != 0 && dieFlag == false && clearFlag == false) //ゲームパットを動かしていると....
            {
                if (playerRigidbody.velocity.x < playerMaxSpeed &&
                    playerRigidbody.velocity.x > playerMaxSpeed * -1 &&
                    XMoveCount <= dashChangeCount) //速度が最大速度以下で動かした時間が一定以下だと...
                {
                    Move();
                    walkFlag = true; //歩いているフラグ
                }
                else if (playerRigidbody.velocity.x < playerMaxDashSpeed &&
                    playerRigidbody.velocity.x > playerMaxDashSpeed * -1) //動かした時間が一定以上だと...
                {
                    Move();
                }

                //振り向き---------------------------
                Vector3 nowScale = scale;
                if (Axisx > 0)
                {
                    transform.localScale = nowScale; //Xの大きさを反転する。(振り向き)
                }
                else if (Axisx < 0)
                {
                    nowScale.x = -scale.x;
                    transform.localScale = nowScale; //Xの大きさを反転する。(振り向き)
                }
                //-----------------------------
            }
            else //ゲームパットを動かしていないと...
            {
                walkFlag = false; //歩かない
                XMoveCount = 0; //ダッシュに変化させるカウントをリセットする
            }
            //-----------------------------------------------------------------------------------
            //プレイヤーのジャンプ------------------------------------------------
            if (inputParam.m_AButton || inputParam.m_BButton)
            {
                audioSource.PlayOneShot(jampSE);
                jampFlag = true;
            }
            ///dieflag == false  clearFlag == false 追加　米盛
            if (jampFlag == true && jampEndFlag == false && dieflag == false && clearFlag == false)
            {
                Jump();
            }
            //--------------------------------------------------------------------
        }
    }
    public void OnCollisionEnter2D(Collision2D other) //コリジョンに当たったら
    {
        if(other.gameObject.CompareTag("scaffold"))
        {
            playerRigidbody.gravityScale = firstGravityScale / 1.25f; //壁に当たると落下速度が遅くなる
            wallKickEffectOutputFlag = false;
            jampFlag = false;
            jampEndFlag = false;
            leftJampFlag = false;
            rightJampFlag = false;
        }
        else if(other.gameObject.CompareTag("goal"))
        {
            clearFlag = true;
        }
    }
    public void OnCollisionExit2D(Collision2D other) //コリジョンから離れたら
    {
        if (other.gameObject.CompareTag("scaffold"))
        {
            playerRigidbody.gravityScale = firstGravityScale;
            if (playerRigidbody.velocity.y < -0.05f) //速度が一定以下(落下中)だとジャンプができなくなる
            {
                jampFlag = true;
                jampEndFlag = true;
            }
            leftJampFlag = false;
            rightJampFlag = false;
        }
    }
    private void Move() //プレイヤーの動き
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(DashSE,DashSEFrequency);
        }
        XMoveCount += 1 * Time.deltaTime;
        playerRigidbody.velocity += new Vector2(playerSpeed * Time.deltaTime * Axisx, 0); //歩行
        //絶対値計算
        //ひとまずの制限値が５
        if (Mathf.Abs(playerRigidbody.velocity.x) >= 5)
        {
            float velocityLimmit;
            if (playerRigidbody.velocity.x >= 0)
            {
                velocityLimmit = 5;
            }
            else
            {
                velocityLimmit = -5;
            }
            playerRigidbody.velocity = new Vector2(velocityLimmit, playerRigidbody.velocity.y);
        }
    }
    private void Jump() //プレイヤーのジャンプ
    {
        if (Axisx < 0 && playerRigidbody.velocity.x > -0.1f) //壁ジャンプ(左)
        {
            leftJampFlag = true;
            rightJampFlag = false;
        }
        if (Axisx > 0 && playerRigidbody.velocity.x < 0.1f) //壁ジャンプ(右)
        {
            rightJampFlag = true;
            leftJampFlag = false;
        }
        if (jampEndFlag == false ) //ジャンプが終わっていないと
        {
            playerRigidbody.velocity += new Vector2(0, playerJampPower * Time.deltaTime); //普通のジャンプ
            if(leftJampFlag == true && Axisx != 0)
            {
                if (wallKickEffectOutputFlag == false) //壁キックのエフェクトが出てくるフラグ
                {
                    audioSource.PlayOneShot(wallKickSE); //効果音を鳴らす
                    Instantiate(wallKickEffect,transform.position, new Quaternion(0, wallKickEffectAng + 180, 0,0)); //エフェクトを出す
                    wallKickEffectOutputFlag = true;
                }
                playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * 9, 0); //壁ジャンプ(左)
            }
            if (rightJampFlag == true && Axisx != 0)
            {
                if (wallKickEffectOutputFlag == false)  //壁キックのエフェクトが出てくるフラグ
                {
                    audioSource.PlayOneShot(wallKickSE); //効果音を鳴らす
                    Instantiate(wallKickEffect, transform.position, new Quaternion(0, wallKickEffectAng + 180, 0, 0)); //エフェクトを出す
                    wallKickEffectOutputFlag = true;
                }
                playerRigidbody.velocity += new Vector2(-1 * playerDashSpeed * Time.deltaTime * 9, 0); //壁ジャンプ(右)
            }
            if (playerRigidbody.velocity.y > playerJampMax)
            {
                jampEndFlag = true; //ジャンプが終わったフラグ
            }

        }
    }

    /// 変更後　 米盛
    void OnTriggerEnter2D(Collider2D collision)               //衝突したオブジェクトのタグをcollisionに代入
    {
        if (collision.CompareTag("dangerousObj")&&!dieFlag)            //衝突したオブジェクトのタグがdangerousObjなら
        {
            animator.SetTrigger("dieTrigger");
            dieFlag = true;
            setDeadObj.deadPlayerNum++;
        }
        else if(collision.CompareTag("goal")&&!dieFlag)
        {
            clearFlag = true;
        }
    }
    private void OnEnable()
    {
        m_reSpornProcess.ReSporn();
        clearFlag = false;
        animator.SetBool("dieflag", false);
        dieFlag = false;
        jampEndFlag = true;
        jampFlag = false;
    }
    void dieanimeend() //死ぬモーション終了用イベント
    {
        animator.SetBool("dieflag", true);
    }
}
