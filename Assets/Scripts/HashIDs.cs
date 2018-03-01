using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour {

    //Animations

    //Camera
    public static int cameraZoomOutHash = Animator.StringToHash("startZoomOut");
    public static int cameraZoomInHash = Animator.StringToHash("startZoom");
    public static int cameraSlideToGoalsFromMain = Animator.StringToHash("startSlideToGoalsFromMain");
    public static int cameraSlideToGoalsFromGameplay = Animator.StringToHash("startSlideToGoalsFromGameplay");
    public static int cameraSlideToMain = Animator.StringToHash("startSlideToMain");
    public static int cameraSlideToGameplay = Animator.StringToHash("startSlideToGameplay");
    public static int cameraGameoverHash = Animator.StringToHash("gameover");
    public static int startFadeHash = Animator.StringToHash("startFade");
    public static int calculationHash = Animator.StringToHash("calculation");
    public static int calculationStartHash = Animator.StringToHash("calculationShow");
    public static int replayHash = Animator.StringToHash("replay");
    public static int noReplayHash = Animator.StringToHash("noReplay");

    //Ring
    public static int ringFadeOutHash = Animator.StringToHash("startFade");

    //Log Text
    public static int logTextFadeStateNameHash = Animator.StringToHash("Log Text Fade Animation");

    //Combo Text
    public static int comboTextFadeStateNameHash = Animator.StringToHash("Combo Text Fade Animation");

    public static int cameraLayerHash = Camera.main.GetComponent<Animator>().GetLayerIndex("Base Layer");


    public static int cameraStateHashSlideToGoalsFromMain = Animator.StringToHash("Slide To Goals From Main");


    public static int cloudGradientLeftStartHash = Animator.StringToHash("start left");
    public static int cloudGradientRightStartHash = Animator.StringToHash("start right");
    public static int cloudGradientLeftEndHash = Animator.StringToHash("end left");
    public static int cloudGradientRightEndHash = Animator.StringToHash("end right");
    public static int cloudGradientEndHash = Animator.StringToHash("end");

    //Fish
    public static int fishLeftHash = Animator.StringToHash("Left");

}
