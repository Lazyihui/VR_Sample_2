using System;
using UnityEngine;


public class CameraCore {
    public Camera camera;

    // 相机跟谁
    public void GameraFollow(Vector3 follow_Target, Vector2 follow_Offset, float follow_distance, Vector3 face, float dt) {

        Camera cam = camera;

        cam.transform.position = follow_Target + new Vector3(follow_Offset.x, follow_Offset.y, follow_distance);

        // 面向==head.pos
        cam.transform.forward = face;

    }

    public CameraCore(){
        
    }
    public void Inject(Camera camera) {
        this.camera = camera;
    }
}