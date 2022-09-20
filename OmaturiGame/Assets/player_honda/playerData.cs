using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "データ/CreatplayerData")]

public class playerData : ScriptableObject
{
    [Header("プレイヤーの速度(加速する速さ):(0.0 ~ 10.0)")]
    [Header("--------------------------------")]
    [Range(0, 10)]
    public float speed;
    [Range(0, 10)]
    [Header("プレイヤーの最大速度:(0.0 ~ 10.0)")]
    public float maxSpeed;
    [Header("プレイヤーがダッシュに変わるまでの時間:(0秒.0 ~ 10秒.0)")]
    [Header("--------------------------------")]
    [Range(0, 10)]
    public float dashcount;
    [Header("プレイヤーのダッシュの速度(加速する速さ):(0.0 ~ 20.0)")]
    [Range(0, 20)]
    public float dashSpeed;
    [Header("プレイヤーのダッシュの最大速度:(0.0 ~ 30.0)")]
    [Range(0, 30)]
    public float maxdashSpeed;
    [Header("プレイヤーのジャンプのエネルギー(加速する速さ):(50.0 ~ 200.0)")]
    [Header("--------------------------------")]
    [Range(50, 200)]
    public float jumpPower;
    [Header("プレイヤーのジャンプの最大:(1.0 ~ 10.0)")]
    [Range(1, 10)]
    public float jumpMax;

}
