using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Target : MonoBehaviour, ITarget
{
    public Vector3 TargetPosition => transform.position;

    public bool IsDead => throw new NotImplementedException();

    public bool NeedHeal => throw new NotImplementedException();

    public float Life => throw new NotImplementedException();

    public event Action<bool> OnNeedHeal;
    public event Action<float> OnLife;
    public event Action OnDie;

    public void AddLife(float _life)
    {
        throw new NotImplementedException();
    }

    public void SetDamage(float _dmg)
    {
        throw new NotImplementedException();
    }
}
