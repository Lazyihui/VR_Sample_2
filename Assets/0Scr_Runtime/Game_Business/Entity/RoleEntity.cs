using System;
using UnityEngine;


public class RoleEntity : MonoBehaviour {

    [SerializeField] public GameObject head;
    public int id;

    public float speed;

    public void Ctor() {
        speed = 5.5f;
    }

   

    public void SetPos(Vector3 pos) {
        this.transform.position = pos;
    }

}