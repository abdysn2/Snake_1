using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryPlacer : MonoBehaviour
{
    public Camera targetCamera;
    public EdgeCollider2D topBoundary;
    public EdgeCollider2D downBoundary;
    public EdgeCollider2D rightBoundary;
    public EdgeCollider2D leftBoundary;

    void Start()
    {
        var hight = targetCamera.orthographicSize;
        var width = targetCamera.aspect * hight;
        SetBoundery(topBoundary, width, 0);
        topBoundary.transform.position = new Vector3(0, hight, 0);
        SetBoundery(downBoundary, width, 0);
        downBoundary.transform.position = new Vector3(0, -hight, 0);
        SetBoundery(rightBoundary, hight, 90);
        rightBoundary.transform.position = new Vector3(width, 0, 0);
        SetBoundery(leftBoundary, hight, 90);
        leftBoundary.transform.position = new Vector3(-width, 0, 0);
    }

    private void SetBoundery(EdgeCollider2D boundery, float length, int rotation)
    {
        Vector2[] newPoints = { Vector2.right * -length,
                                Vector2.right * length};
        boundery.points = newPoints;
        boundery.transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
