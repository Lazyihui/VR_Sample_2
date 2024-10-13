using System;
using UnityEngine;



public class PointEntity : MonoBehaviour {

    public int id;

    public float speed;


    public void Ctor() {

    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
    
}