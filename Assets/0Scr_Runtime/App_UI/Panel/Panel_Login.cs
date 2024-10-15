using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panel_Login : MonoBehaviour {
    [SerializeField] Button btnLogin;

    [SerializeField] public TextMeshProUGUI txtTitle;

    public Char[] textContent;

    public Action OnbtnClick;

    public int index;

    public int time;

    public void Ctor() {
        btnLogin.onClick.AddListener(() => {
            OnbtnClick?.Invoke();
        });

        textContent = txtTitle.text.ToCharArray();
        index = 0;

        txtTitle.text = "";
        btnLogin.gameObject.SetActive(false);
    }

    public void Update() {

        time++;
        if (time % 5 == 0) {

            if (index < textContent.Length) {
                txtTitle.text += textContent[index];
                index++;
            } else {
                btnLogin.gameObject.SetActive(true);
            }
        }

    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        Destroy(gameObject);
    }
}