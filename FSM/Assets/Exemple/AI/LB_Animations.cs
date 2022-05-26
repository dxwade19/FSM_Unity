using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_Animations : MonoBehaviour
{
    [SerializeField] Animator animations = null;
    [SerializeField] string walkParam = "walk", aimParam = "aim", shootParam = "shoot", panicParam = "panic_speed";

    public bool IsValid => animations;


    public Animator Animation => animations;

    public void SetWalksAnimation(bool _status)
    {
        if (!IsValid) return;
        animations.SetBool(walkParam, _status);
    }

    public void SetAimAnimation(bool _status)
    {
        if (!IsValid) return;
        animations.SetBool(aimParam, _status);
    }

    public void SetShootAnimation(bool _status)
    {
        if (!IsValid) return;
        animations.SetBool(shootParam, _status);
    }

    public void SetPanicSpeedAnimation(float _value)
    {
        if (!IsValid) return;
        animations.SetFloat(panicParam, _value);
    }

    public void ResetAnimation()
    {
        SetWalksAnimation(false);
        SetAimAnimation(false);
        SetShootAnimation(false);
        SetPanicSpeedAnimation(1);
    }

}

//TODO Generic Animation
