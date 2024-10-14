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

    public void MoveUpDown(float y, float dt) {
        Vector3 moveDir = new Vector3(0, y, 0);
        moveDir.Normalize();

        moveDir = this.transform.rotation * moveDir;
        moveDir = moveDir * speed * dt;
        this.transform.position += moveDir;
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