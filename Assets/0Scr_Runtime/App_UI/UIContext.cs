using System;
using UnityEngine;


public class UIContext {
    public Panel_Login panel_Login;

    public Panel_A panel_A;

    public UIEvent uiEvent;

    public AssetContext assetContext;
    public UIContext() {
        uiEvent = new UIEvent();
    }

    public void Inject(AssetContext assetContext) {
        this.assetContext = assetContext;
     }
}