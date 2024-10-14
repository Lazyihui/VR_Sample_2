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
    }

    public static void Panel_LoginClose(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;
        if (panel == null) {
            return;
        }
        panel.TearDown();
    }

    public static void Panel_AOpen(UIContext ctx) {
        Panel_A panel = ctx.panel_A;

        bool has = ctx.assetContext.entities.TryGetValue("Panel_A", out GameObject prefab);
        if (has) {

            GameObject go = GameObject.Instantiate(prefab);
            panel = go.GetComponent<Panel_A>();

            panel.Ctor();

        }

        ctx.panel_A = panel;
        panel.Show();
    }

    public static void Panel_AClose(UIContext ctx) {
        Panel_A panel = ctx.panel_A;
        if (panel == null) {
            return;
        }

        panel.TearDown();
    }

}