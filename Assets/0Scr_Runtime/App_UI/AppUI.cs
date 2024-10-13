using System;
using UnityEngine;



public static class AppUI {

    public static void Panel_LoginOpen(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;

        bool has = ctx.assetContext.entities.TryGetValue("Panel_Login", out GameObject prefab);
        if (has) {

            GameObject go = GameObject.Instantiate(prefab);
            panel = go.GetComponent<Panel_Login>();

            panel.Ctor();
            panel.OnbtnClick = () => {
                ctx.uiEvent.OnBtnLoginHandleClick();
            };
        }

        ctx.panel_Login = panel;
        panel.Show();
        Debug.Log("Panel_LoginOpen");
    }

    public static void Panel_LoginClose(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;
        if (panel == null) {
            return;
        }
        panel.TearDown();
    }

}