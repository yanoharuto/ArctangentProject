using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour
{
    // 点滅させる対象
    [SerializeField] public Renderer _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;

    private float _time;

    private void Update()
    {
        // 内部時刻を経過させる
        _time += Time.deltaTime;

        // 周期cycleで繰り返す値の取得
        // 0〜cycleの範囲の値が得られる
        var repeatValue = Mathf.Repeat(_time, _cycle);

        // 内部時刻timeにおける明滅状態を反映
        _target.enabled = repeatValue >= _cycle * 0.5f;
    }
}
