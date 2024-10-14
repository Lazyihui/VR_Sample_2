using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_A : MonoBehaviour {


    public void Ctor() {

    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        Destroy(gameObject);
    }
}