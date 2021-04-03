using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    private Vector3[] splinePoint;
    private int splineCount;

    public bool debug_drawSpline = true;

    private void Start()
    {
        
        {
            splineCount = transform.childCount;
            splinePoint = new Vector3[splineCount];

            for (int i = 0; i < splineCount; i++)
            {
                splinePoint[i] = transform.GetChild(i).position;
            }
        }

       
    }
    private void Update()
    {
        if ( splineCount > 1)
        {
            for (int i = 0; i < splineCount - 1; i++)
            {
                Debug.DrawLine(splinePoint[i], splinePoint[i + 1], Color.green);
            }
        }
    }

    public Vector3 WhereOnSpline (Vector3 pos)
    {
        int ClosestSplinePoint = GetClosestSplinePoint(pos);

        if (ClosestSplinePoint == 0)
        {
            return splineSegment(splinePoint[0], splinePoint[1], pos);
        }
        else if (ClosestSplinePoint == splineCount -1)
        {
            return splineSegment(splinePoint[splineCount - 1], splinePoint[splineCount - 2 ], pos);
        }
        else
        {
            Vector3 leftSeq = splineSegment(splinePoint[ClosestSplinePoint - 1], splinePoint[ClosestSplinePoint], pos);
            Vector3 rightSeq = splineSegment(splinePoint[ClosestSplinePoint + 1], splinePoint[ClosestSplinePoint], pos);

            if ((pos - leftSeq).sqrMagnitude <= (pos - rightSeq).sqrMagnitude)
            {
                return leftSeq;
            }
            else
            {
                return rightSeq;
            }
        }
    }
        
    private int GetClosestSplinePoint(Vector3 pos)
    {
        int closestPoint = -1;
        float shortestDistance = 0.0f;

        for (int i = 0; i < splineCount; i++)
        {
            float sqrDistance = (splinePoint[i] - pos).sqrMagnitude;
            if(shortestDistance == 0.0f || sqrDistance < shortestDistance)
            {
                shortestDistance = sqrDistance;
                closestPoint = i;
            }
        }

        return closestPoint;

    }

    public Vector3 splineSegment (Vector3 v1, Vector3 v2, Vector3 pos)
    {
        Vector3 v1ToPos = pos - v1;
        Vector3 seqDircetion = (v2 - v1).normalized;

        float distanceFromV1 = Vector3.Dot(seqDircetion, v1ToPos);

        if ( distanceFromV1 < 0.0f)
        {
            return v1;
        }
        else if (distanceFromV1 * distanceFromV1 > (v2 -v1).sqrMagnitude)
        {
            return v2;
        }
        else
        {
            Vector3 fromv1 = seqDircetion * distanceFromV1;
            return v1 + fromv1;
        }
    }
}

