using System;
using UnityEngine;


public class PlaneEntity : MonoBehaviour {

    [SerializeField] GameObject ray;

    public int id;


    public float moveSpeed;


    public void Ctor() {
        moveSpeed = 5.5f;
        ray.gameObject.SetActive(false);
    }

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