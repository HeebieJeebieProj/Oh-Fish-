using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileUtilsScript : MonoBehaviour
{

    public static int FramesPerSec;
    private float frequency = 1.0f;
    private string fps;

    void Start()
    {
        FramesPerSec = 60;
        StartCoroutine(FPS());
    }

    private void Update()
    {
        GetComponent<Text>().text = fps;
    }

    private IEnumerator FPS()
    {
        for (;;)
        {
            // Capture frame-per-second
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            // Display it

            FramesPerSec = Mathf.RoundToInt(frameCount / timeSpan);

            fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
        }
    }
    
}
