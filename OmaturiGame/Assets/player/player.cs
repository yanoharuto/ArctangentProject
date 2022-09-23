using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    [SerializeField] //playerStatusの読み込み
    [Header("Playerのステータス")]
    public playerData playerStatus;//playerData型のplayerStatusを入れる
    [SerializeField]
    [Header("地面当たり判定")]
    public GameObject groundCollider;//playerData型のplayerStatusを入れる


    GroundCheckPlayer flag;
    Rigidbody2D playerRigidbody; //Rigidbody2D型の変数
    float playerSpeed; //プレイヤーの速度
    float playerMaxSpeed; //プレイヤーの最大速度
    float playerDashSpeed;//プレイヤーのダッシュ速度
    float playerMaxDashSpeed; //プレイヤーの最大ダッシュ速度
    float playerJampPower; //プレイヤーのジャンプする大きさ
    float playerJampMax; //プレイヤーのジャンプの限界
    float firstGravityScale; //初めの重力スケール
    float XMoveCount; //どれ位左右キーを押したか
    float dashChangeCount; //ダッシュに代わるまでの時間
    bool rightJampFlag; //右に壁ジャンプできるフラグ
    bool leftJampFlag;　//左に壁ジャンプできるフラグ
    bool jumpFlag; //ジャンプキーを押したかを判定
    bool IsFly; //ジャンプ時の上昇が終了したかの判定
    
    float InputVecX;
    float InputVecY;

    //ボタンの名前を検索しやすいよう定義-----------------------------------
    const string m_inputVecNameX = "Horizontal";
    const string m_inputVecNameY = "Vertical";
    const string m_InputJump = "Xbox_A";
    //-----------------------------------------------------
    Vector3 DefaultScale;


    //アニメーション関係-----------------------------------
    Animator animator; //Animator型の変数
    bool RunFlag; //歩いているかどうかの判定
    //-----------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        DefaultScale = transform.localScale;
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
        flag = groundCollider.GetComponent<GroundCheckPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

        //アニメーション関係-----------------------------------
        animator.SetBool("RunFlag", RunFlag);
        //animator.SetBool("dashFlag", dashFlag);
        animator.SetBool("jumpFlag", jumpFlag);
        animator.SetFloat("FoolVelocity.y", playerRigidbody.velocity.y);

        //animator.SetBool("follFlag", jampFlag);
        //animator.SetFloat("velocty.y", playerRigidbody.velocity.y);
        //-----------------------------------------------------
        //プレイヤーの左右移動-----------------------------------------
        InputVecX = Input.GetAxis(m_inputVecNameX);//-1~1の範囲で横軸のスティック入力を取得
        InputVecY = Input.GetAxis(m_inputVecNameY);//-1~1の範囲で縦軸のスティック入力を取得

        //Debug.Log(InputVecX);
        //Debug.Log(InputVecY);
        //Debug.Log(Input.GetButtonDown(m_InputJump));
        if (IsMove())
        {
            RunFlag = true;
            Move();
            
        }
        else
        {
            RunFlag = false;
        }

        if (jumpFlag && flag.IsGround()&& playerRigidbody.velocity.y<=0)
        {
            jumpFlag = false;
        }
        Debug.Log(jumpFlag);
        if (Input.GetButtonDown(m_InputJump))//ジャンプ
        {
            Jump();
            
        }
        
        //if (IsMove()) //ゲームパットを動かしていると....
        //{
        //    if (playerRigidbody.velocity.x < playerMaxSpeed && 
        //        playerRigidbody.velocity.x > playerMaxSpeed * -1 && 
        //        XMoveCount <= dashChangeCount) //速度が最大速度以下で動かした時間が一定以下だと...
        //    {
        //        Move();
        //        walkFlag = true; //歩いているフラグ
        //    }
        //    else if (playerRigidbody.velocity.x < playerMaxDashSpeed && 
        //        playerRigidbody.velocity.x > playerMaxDashSpeed * -1) //動かした時間が一定以上だと...
        //    {
        //        Move();
        //        dashFlag = true; //動きがダッシュに変化する
        //        walkFlag = false;
        //    }
        //    //振り向き---------------------------47
        if (InputVecX > 0)
        {
            transform.localScale = Vector3.Scale(DefaultScale,new Vector3(1, 1, 1)); //Xの大きさを反転する。(振り向き)
        }
        else if (InputVecX < 0)
        {
            transform.localScale = Vector3.Scale(DefaultScale, new Vector3(-1, 1, 1)); ; //Xの大きさを反転する。(振り向き)
        }
        //    //-----------------------------
        //}
        //else //ゲームパットを動かしていないと...
        //{
        //    dashFlag = false; //走らない
        //    walkFlag = false; //歩かない
        //    XMoveCount = 0; //ダッシュに変化させるカウントをリセットする
        //}
        ////-----------------------------------------------------------------------------------
        ////プレイヤーのジャンプ------------------------------------------------
        //if(Input.GetKeyDown(KeyCode.Joystick1Button1))
        //{
        //    jampFlag = true;
        //}
        //if(jampFlag == true && jampEndFlag == false)
        //{
        //    Jump();
        //}
        ////--------------------------------------------------------------------
    }
    public void OnCollisionEnter2D(Collision2D other) //コリジョンに当たったら
    {

        //if (other.gameObject.CompareTag("scaffold"))
        //{
        //    playerRigidbody.gravityScale = firstGravityScale / 1.25f; //壁に当たると落下速度が遅くなる
        //    jampFlag = false;
        //    jampEndFlag = false;
        //    leftJampFlag = false;
        //    rightJampFlag = false;
        //}
    }
    public void OnCollisionExit2D(Collision2D other) //コリジョンから離れたら
    {
        //if (other.gameObject.CompareTag("scaffold"))
        //{
        //    playerRigidbody.gravityScale = firstGravityScale;
        //    if (playerRigidbody.velocity.y < -0.05f) //速度が一定以下(落下中)だとジャンプができなくなる
        //    {
        //        jampFlag = true;
        //        jampEndFlag = true;
        //    }
        //    leftJampFlag = false;
        //    rightJampFlag = false;
        //}
    }

    private void Move() //プレイヤーの動き
    {

        playerRigidbody.velocity = new Vector2(/*playerDashSpeed*/ 15 *InputVecX, playerRigidbody.velocity.y); //走る

        //XMoveCount += 1 * Time.deltaTime;
        //playerRigidbody.velocity += new Vector2(playerSpeed * Time.deltaTime * InputVecX, 0); //歩行
        //if(XMoveCount >= dashChangeCount)
        //{
        //    playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * InputVecX, 0); //走る
        //}
    }
    private void Jump() //プレイヤーのジャンプ
    {
        //playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 5);
        if(!jumpFlag)
        {
            jumpFlag = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 10);
        }
        
        


        //if (InputVecX < 0 && playerRigidbody.velocity.x > -0.1f) //壁ジャンプ(左)
        //{
        //    leftJampFlag = true;
        //    rightJampFlag = false;
        //}
        //if (InputVecX > 0 && playerRigidbody.velocity.x < 0.1f) //壁ジャンプ(右)
        //{
        //    rightJampFlag = true;
        //    leftJampFlag = false;
        //}
        //if (jampEndFlag == false ) //ジャンプが終わっていないと
        //{
        //    playerRigidbody.velocity += new Vector2(0, playerJampPower * Time.deltaTime); //普通のジャンプ
        //    if(leftJampFlag == true && InputVecX != 0)
        //    {
        //        playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * 9, 0); //壁ジャンプ(左)
        //    }
        //    if (rightJampFlag == true && InputVecX != 0)
        //    {
        //        playerRigidbody.velocity += new Vector2(-1 * playerDashSpeed * Time.deltaTime * 9, 0); //壁ジャンプ(右)
        //    }
        //    if (playerRigidbody.velocity.y > playerJampMax)
        //    {
        //        jampEndFlag = true; //ジャンプが終わったフラグ
        //    }

        //}
    }

    private bool IsMove()
    {
        if (InputVecX!=0)
        {
            return true;
        }
        return false;
    }
    
}
