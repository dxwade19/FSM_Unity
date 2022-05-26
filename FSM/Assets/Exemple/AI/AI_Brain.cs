using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Brain : MonoBehaviour
{
    [SerializeField] LB_Animations animations = null;
    [SerializeField] AP_Movements mouvements = null;
    [SerializeField] AI_WayPointSystem pattern = null;
    [SerializeField] CS_ConeSight detectionSystem = null;
    [SerializeField, Header("Statistics")] protected AI_Statitistiques statistics = null;
    FSM_StateMachine stateMachine = new FSM_StateMachine();


    public FSM_StateMachine StateMachine => stateMachine;
    public LB_Animations Animation => animations;
    public AP_Movements Mouvements => mouvements;
    public AI_WayPointSystem Pattern => pattern;
    public CS_ConeSight DetectionSystem => detectionSystem;
    public AI_Statitistiques Statistics => statistics;

    public bool IsPattern = true;
    public bool IsDetected = false;
    public bool IsWait = false;

    public bool IsValid => stateMachine != null && animations && mouvements && detectionSystem && statistics != null;


    void Start() => InitBrain();

    void InitBrain()
    {
        if (!IsValid) return;
        stateMachine.Brain = this;
        FSM_PatrolState _patrol = new FSM_PatrolState(this);

        mouvements.OnPositionReached += () => IsPattern = false;
        detectionSystem.OnTargetDetected += (target) =>
        {
            IsPattern = false;
            IsWait = false;
            IsDetected = true;
        };
        detectionSystem.OnTargetLost += (targetPos) =>
        {
            IsPattern = true;
            IsWait = false;
            IsDetected = false;
        };

        StartCoroutine(stateMachine.StartFSm(_patrol).GetEnumerator());
    }


}
