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
    public static int startFadeHash = Animator.StringToHash("startFade");

    //Ring
    public static int ringFadeOutHash = Animator.StringToHash("startFade");

    //Log Text
    public static int logTextFadeStateNameHash = Animator.StringToHash("Log Text Fade Animation");

    //Combo Text
    public static int comboTextFadeStateNameHash = Animator.StringToHash("Combo Text Fade Animation");

    public static int cameraLayerHash = Camera.main.GetComponent<Animator>().GetLayerIndex("Base Layer");


    public static int cameraStateHashSlideToGoalsFromMain = Animator.StringToHash("Slide To Goals From Main");

}
