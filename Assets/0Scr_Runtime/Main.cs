using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    GameContext ctx;

    bool isTearDown = false;

    void Awake() {
        ctx = new GameContext();

        Debug.Assert(ctx != null);


        AssetsCore.Load(ctx.assetContext);

        Debug.Log("hel  ");

        Game_Business.Enter(ctx);

    }

    void Update() {

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
