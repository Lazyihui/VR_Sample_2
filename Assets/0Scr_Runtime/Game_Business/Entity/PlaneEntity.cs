using System;
using UnityEngine;


public class PlaneEntity : MonoBehaviour {

    public int id;


    public float moveSpeed;


    public void Ctor() {
        moveSpeed = 5.5f;

    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }

}