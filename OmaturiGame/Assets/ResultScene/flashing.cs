using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour
{
    // “_–Å‚³‚¹‚é‘ÎÛ
    [SerializeField] public Renderer _target;
    // “_–ÅŽüŠú[s]
    [SerializeField] private float _cycle = 1;

    private float _time;

    private void Update()
    {
        // “à•”Žž‚ðŒo‰ß‚³‚¹‚é
        _time += Time.deltaTime;

        // ŽüŠúcycle‚ÅŒJ‚è•Ô‚·’l‚ÌŽæ“¾
        // 0`cycle‚Ì”ÍˆÍ‚Ì’l‚ª“¾‚ç‚ê‚é
        var repeatValue = Mathf.Repeat(_time, _cycle);

        // “à•”Žžtime‚É‚¨‚¯‚é–¾–Åó‘Ô‚ð”½‰f
        _target.enabled = repeatValue >= _cycle * 0.5f;
    }
}
