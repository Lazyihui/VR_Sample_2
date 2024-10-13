using System;
using System.Collections.Generic;

using UnityEngine;



public class UIEvent {
    public Action OnBtnLoginHandle;

    public void OnBtnLoginHandleClick() {
        if (OnBtnLoginHandle != null) {
            OnBtnLoginHandle.Invoke();
        }
    }
}