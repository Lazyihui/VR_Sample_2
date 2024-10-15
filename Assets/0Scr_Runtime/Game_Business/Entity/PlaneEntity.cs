using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PlaneEntity : MonoBehaviour {

    [SerializeField] GameObject ray;

    [SerializeField] XRRayInteractor rayInteractor;


    public int id;

    public Vector3 endPos;
    public float moveSpeed;


    public void Ctor() {
        moveSpeed = 5.5f;
        ray.gameObject.SetActive(false);
    }

    public void Update() {
        endPos = rayInteractor.rayEndPoint;

        rayInteractor.raycastMask = LayerMask.GetMask("Plane");

        // rayInteractor.hitClosestOnly;

        bool has = rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit,out int raycastEndpointIndex);




        if (has) {
        
            Debug.Log(raycastEndpointIndex);
            Debug.Log("hit:" + hit.point + " " + hit.collider.gameObject.name + hit.transform.name);
        }

        rayInteractor.raycastTriggerInteraction = QueryTriggerInteraction.Collide;




        // if (rayInteractor.TryGetHitInfo(out RaycastHit hitInfo)) {
        //     {
        //         Debug.Log("hitInfo:" + hitInfo.point);
        //     }
        // }
    }


    // 碰撞检测
   

    public void ShowRay() {
        ray.gameObject.SetActive(true);
    }

    public void CloseRay() {
        ray.gameObject.SetActive(false);
    }



    public void TearDown() {
        GameObject.Destroy(gameObject);
    }

}