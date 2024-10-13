using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] Camera mainCamera;
    GameContext ctx;

    bool isTearDown = false;

    void Awake() {
        ctx = new GameContext();

        ctx.Inject(mainCamera);

        AssetsCore.Load(ctx.assetContext);

        Game_Business.Enter(ctx);

        Binging();

    }

    void Binging() {
        var uiEvent = ctx.uiContext.uiEvent;

        uiEvent.OnBtnLoginHandle = () => { 
            Debug.Log("OnBtnLoginHandle");
            AppUI.Panel_LoginClose(ctx.uiContext);
            PointDomain.Spawn(ctx);
        };



        }

    void Update() {
        float dt = Time.deltaTime;

        Game_Business.Tick(ctx, dt);

    }


    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }

        isTearDown = true;
        Debug.Assert(ctx != null);
        AssetsCore.UnLoad(ctx.assetContext);
    }

}
