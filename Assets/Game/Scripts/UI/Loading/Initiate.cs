using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Initiate
{
    static bool areWeFading = false;

    static GameObject initTemp = null;

    public static void Fade(string scene, Color col, float multiplier)
    {
        if (areWeFading)
        {
            Debug.Log("Already Fading");
            return;
        }

        GameObject init = new GameObject();
        init.name = "Fader";
        Canvas myCanvas = init.AddComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        init.AddComponent<Fader>();
        init.AddComponent<CanvasGroup>();
        init.AddComponent<Image>();

        Fader scr = init.AddComponent<Fader>();
        scr.fadeDamp = multiplier;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        areWeFading = true;
        scr.InitiateFader();
    }

    public static void FadeTemp(string scene, Color col, float multiplier)
    {
        if (areWeFading)
        {
            Debug.Log("Already Fading");
            return;
        }

        if (initTemp == null)
        {
            initTemp = new GameObject();
            initTemp.name = "Fader";
            Canvas myCanvas = initTemp.AddComponent<Canvas>();
            myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            initTemp.AddComponent<Fader>();
            initTemp.AddComponent<CanvasGroup>();
            initTemp.AddComponent<Image>();

        }

        Fader scr = initTemp.GetComponent<Fader>();
        scr.fadeDamp = multiplier;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        scr.start = true;
        areWeFading = true;
        scr.InitiateFader();

    }

    public static void DoneFading()
    {
        areWeFading = false;
    }
}
