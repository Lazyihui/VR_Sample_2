using System;
using UnityEngine;


public class CameraEntity : MonoBehaviour {

    [SerializeField] Camera cam;

    public void Stand_Follow(Vector3 follow_Target, Vector2 follow_Offset, float follow_distance, Vector3 face, float dt) {

        transform.position = follow_Target + new Vector3(follow_Offset.x, follow_Offset.y, follow_distance);
        // 面向==head.pos
        transform.forward = face;

    }

    // rotate round

    public void Round(Vector3 centerPos, float distance, Vector3 angleOffset) {

        Vector3 pos = GetRoundPos(transform.position, centerPos, distance, angleOffset);
        transform.position = pos;
    }

    Vector3 GetRoundPos(Vector3 pointOnSphere, Vector3 sphereCenter, float radius, Vector3 angleOffset) {
        Vector3 dir = pointOnSphere - sphereCenter;
        dir.Normalize();

        Vector3 newDir = Quaternion.Euler(angleOffset) * dir;

        Vector3 newPointOnSphere = sphereCenter + newDir * radius;
        return newPointOnSphere;
    }


    public void cma_rotate(Vector3 forward) {
        cam.transform.forward = forward;
    }

  

}