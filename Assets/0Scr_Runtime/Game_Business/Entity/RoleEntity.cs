using System;
using UnityEngine;


public class RoleEntity : MonoBehaviour {

    [SerializeField] public GameObject head;

    [SerializeField] public GameObject leftHand;

    [SerializeField] public GameObject rightHand;


    public int id;

    public float speed;

    public void Ctor() {
        speed = 5.5f;
    }



    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }
    // 手隐藏
    public void HitHead() {
        leftHand.gameObject.SetActive(false);
        rightHand.gameObject.SetActive(false);

    }

    // 所有归零
    public void SetPos() {
        head.transform.position = Vector3.zero;
        leftHand.transform.position = Vector3.zero;
        rightHand.transform.position = Vector3.zero;

    }

}