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
    Vector3 scale;
    //アニメーション関係-----------------------------------
    Animator animator; //Animator型の変数
    bool walkFlag; //歩いているかどうかの判定
    //-----------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
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
        //アニメーション関係-----------------------------------
        animator.SetBool("walkFlag", walkFlag);
        animator.SetBool("jampFlag", jampFlag);
        animator.SetBool("follFlag", jampFlag);
        animator.SetFloat("velocty.y", playerRigidbody.velocity.y);
        //-----------------------------------------------------
        //プレイヤーの左右移動-----------------------------------------
        InputParameter inputParam = inputGetter.GetInputParam();
        Axisx = inputParam.m_LStickHValue;
        if (Axisx != 0) //ゲームパットを動かしていると....
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
                transform.localScale = nowScale ; //Xの大きさを反転する。(振り向き)
            }
            else if(Axisx < 0)
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
        if(inputParam.m_AButton||inputParam.m_BButton)
        {
            jampFlag = true;
        }
        if(jampFlag == true && jampEndFlag == false)
        {
            Jump();
        }
        //--------------------------------------------------------------------
    }
    public void OnCollisionEnter2D(Collision2D other) //コリジョンに当たったら
    {
        if(other.gameObject.CompareTag("scaffold"))
        {
            playerRigidbody.gravityScale = firstGravityScale / 1.25f; //壁に当たると落下速度が遅くなる
            jampFlag = false;
            jampEndFlag = false;
            leftJampFlag = false;
            rightJampFlag = false;
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
        XMoveCount += 1 * Time.deltaTime;
        playerRigidbody.velocity += new Vector2(playerSpeed * Time.deltaTime * Axisx, 0); //歩行
        if(XMoveCount >= dashChangeCount)
        {
            playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * Axisx, 0); //走る
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
                playerRigidbody.velocity += new Vector2(playerDashSpeed * Time.deltaTime * 9, 0); //壁ジャンプ(左)
            }
            if (rightJampFlag == true && Axisx != 0)
            {
                playerRigidbody.velocity += new Vector2(-1 * playerDashSpeed * Time.deltaTime * 9, 0); //壁ジャンプ(右)
            }
            if (playerRigidbody.velocity.y > playerJampMax)
            {
                jampEndFlag = true; //ジャンプが終わったフラグ
            }

        }
    }
    private void Die() //プレイヤーの死亡判定
    {
        animator.SetTrigger("dieTrigger");
    }
    private void OnEnable()
    {
        m_reSpornProcess.ReSporn();
    }
    void dieanimeend() //死ぬモーション終了用イベント
    {
        animator.SetBool("dieflag",true);
    }
}
