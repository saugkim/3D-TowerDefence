using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {


    public int vertexIndex;
    public float lineWidth = 0.05f;
    public float radius;

    bool circleFullScreen;
    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupCircle();
    }

    private void SetupCircle()
    {
        lineRenderer.widthMultiplier = lineWidth;

        if(circleFullScreen)
        {
            radius = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMax, 0f)), 
                            Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMin, 0f ))) *0.5f - lineWidth;
        }

        float deltaTheta = (2f * Mathf.PI) / vertexIndex;
        float theta = 0f;

        lineRenderer.positionCount = vertexIndex;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), 0f,  radius * Mathf.Sin(theta));
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
           
        }
    }
    
    /*
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / vertexIndex;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertexIndex + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), 0f, radius * Mathf.Sin(theta));
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;
        }

    }
    */
}
