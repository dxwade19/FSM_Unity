using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LB_InvestigateBehaviour : MonoBehaviour
{
    [SerializeField, Range(1, 20)] float investigationRadius = 5;
    float initRadiusValue = 5;

    Vector3 investigationStartPos = Vector3.zero, investigationPoint = Vector3.zero;
    List<Vector3> historicPoints = new List<Vector3>();

    void Awake() => initRadiusValue = investigationRadius;

    public void SetLastSeenTarget(Vector3 _lastPoint)
    {
        historicPoints.Clear();
        investigationStartPos = _lastPoint;
        investigationRadius = initRadiusValue;
    }
    public Vector3 GetInvstigationPoint()
    {
        int _angle = Random.Range(0, 360);
        float _x = Mathf.Cos(_angle * Mathf.Deg2Rad) * investigationRadius;
        float _y = 0;
        float _z = Mathf.Sin(_angle * Mathf.Deg2Rad) * investigationRadius;
        investigationPoint = new Vector3(_x, _y, _z) + investigationStartPos;
        historicPoints.Add(investigationPoint);
        return investigationPoint;
    }

    public void SetRadiusMuliplicator(float _multiplicator) => investigationRadius = initRadiusValue + _multiplicator;
   

    private void OnDrawGizmos()
    {
        investigationStartPos.ToWireCube(Color.cyan, Vector3.one);
        transform.position.ToLine(investigationStartPos, Color.cyan);

        investigationStartPos.ToCircle(investigationRadius, Color.magenta);
        investigationPoint.ToWireCube(Color.yellow, Vector3.one);
        transform.position.ToLine(investigationPoint, Color.yellow);

        for (int i = 0; i < historicPoints.Count; i++)
        {
            Color _color = Color.Lerp(Color.red, Color.green, (float)i / investigationPoint.x);
            historicPoints[i].ToWireSphere(_color, 0.1f);
            historicPoints[i].ToLine(investigationStartPos, _color);
        }
    }
}



//Augmenter la detection et le mouvement a chaque tentatives echouer et reset a 1


//Essayer system d'elimination avec historicpoints
//Essayer des repratir par angle
