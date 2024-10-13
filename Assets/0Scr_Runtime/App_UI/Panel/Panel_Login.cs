using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Login : MonoBehaviour
{
    [SerializeField]  Button btnLogin;

    public  Action OnbtnClick;

    public void Ctor(){
        btnLogin.onClick.AddListener(()=>{
            OnbtnClick?.Invoke();
            Debug.Log("OnbtnClick");
        });
    }

    public void Show(){
        gameObject.SetActive(true);
    }

    public void TearDown(){
        Destroy(gameObject);
    }
}