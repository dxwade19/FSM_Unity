using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class AI_Statitistiques
{
    public event Action<float> OnUpdatePanicLevel = null;
    public event Action OnResetAI = null;

    [SerializeField] int objectiveAttemps = 0, totalReward = 0, totalFail = 0;
    [SerializeField, Range(0, 100)] float attemptPercentReset = 20, currentFailProgress = 0, globalProgress = 0;

    [SerializeField, Header("Panic Level")] bool usePanicLevel = true;
    [SerializeField, Range(1, 5)] float globalpanicLevel = 1;

    public float IA_Fail => (objectiveAttemps / 50f) * 100;
    public bool IA_NeedReset => IA_Fail > attemptPercentReset;
    public float GlobalProgressRatio => (float)totalReward / totalFail;
    public float PanicValue => 1 + (IA_Fail / 50);


    public void AddReward(int _reward = 1)
    {
        totalReward += _reward;
        globalProgress = GlobalProgressRatio;
    }
    public void AddFail(int _fail = 1)
    { 
        totalFail += _fail;
        globalProgress = GlobalProgressRatio;
    }

    public void AddAttempt(int _objectiveAttempts = 1)
    {
        objectiveAttemps += _objectiveAttempts;
        currentFailProgress = IA_Fail;

        if(usePanicLevel)
        {
            globalpanicLevel = PanicValue;
            OnUpdatePanicLevel?.Invoke(globalpanicLevel);
        }
    }

    public void ResetState()
    {
        objectiveAttemps = 0;
        currentFailProgress = IA_Fail;
        globalpanicLevel = 1;
        OnResetAI?.Invoke();
    }
}

//TODO interface
