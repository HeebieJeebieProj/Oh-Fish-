using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour {

    public float[] rangeSpeedForeground;
    public float[] rangeSpeedBackground;

    public Sprite[] cloudBackgroundSprites;
    public Sprite[] cloudForegroundSprites;
    public float[] rangeCloudForegroundScale;
    public float[] rangeCloudBackgroundScale;

    public GameObject cloudForeground;
    public GameObject cloudBackground;
    public Color[] colorsForeground;
    public Color[] colorsBackground;
    public GameObject sun;
    public GameObject moon;

    public float[] rangeYBackgroundClouds;
    public float[] rangeYForegroundClouds;

    public float[] rangeTimeDiffBackground;
    public float[] rangeTimeDiffForeground;

    public GameObject foregroundCloud;
    public GameObject backgroundCloud;

    private bool spawnForegroundClouds;
    private bool spawnBackgroundClouds;

    public float alpha = 0;
    public float radius = 8;

	// Use this for initialization
	void Start () {

        spawnBackgroundClouds = true;
        spawnForegroundClouds = true;

	}
	
	// Update is called once per frame
	void Update () {

        if (spawnBackgroundClouds)
        {
            spawnBackgroundClouds = false;
            StartCoroutine(GenerateBackgroundClouds());
        }

        if (spawnForegroundClouds)
        {
            spawnForegroundClouds = false;
            StartCoroutine(GenerateForegroundClouds());
        }
		
	}

    IEnumerator GenerateBackgroundClouds()
    {

        GameObject cloudClone = Instantiate(
            cloudBackground,
            new Vector3(-13f, Random.Range(rangeYBackgroundClouds[0], rangeYBackgroundClouds[1]), cloudBackground.GetComponent<Transform>().position.z),
            cloudBackground.GetComponent<Transform>().rotation
        );
        cloudClone.GetComponent<ScrollScript>().speed = Random.Range(rangeSpeedBackground[0], rangeSpeedBackground[1]);
        cloudClone.GetComponent<Transform>().parent = backgroundCloud.GetComponent<Transform>();

        cloudClone.GetComponent<CloudColorScript>().colors = colorsBackground;
        cloudClone.GetComponent<CloudColorScript>().sun = sun;
        cloudClone.GetComponent<CloudColorScript>().moon = moon;
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<CloudGradientScript>().alpha = alpha;
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<CloudGradientScript>().radius = radius;
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<CloudGradientScript>().sun = sun;

        float scale = Random.Range(rangeCloudBackgroundScale[0], rangeCloudBackgroundScale[1]);
        cloudClone.GetComponent<Transform>().localScale = new Vector3(scale, scale, 1f);

        int sprite = Random.Range(0, cloudBackgroundSprites.Length / 2);
        cloudClone.GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().sprite = cloudBackgroundSprites[sprite * 2];
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<SpriteRenderer>().sprite = cloudBackgroundSprites[sprite * 2 + 1];

        int[] flipped = new int[2];
        for (int i = 0; i < 2; i++)
        {
            flipped[0] = (int) Random.Range(0, 2);
            flipped[1] = (int)Random.Range(0, 2);
        }
        if (flipped[0] == 1)
        {
            cloudClone.GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().flipX = true;
            cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<SpriteRenderer>().flipX = true;
        }
        if (flipped[1] == 1)
        {
            cloudClone.GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().flipY = true;
            cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<SpriteRenderer>().flipY = true;
        }

        yield return new WaitForSeconds(Random.Range(rangeTimeDiffBackground[0], rangeTimeDiffBackground[1]));

        spawnBackgroundClouds = true;

    }

    IEnumerator GenerateForegroundClouds()
    {

        GameObject cloudClone = Instantiate(
            cloudForeground,
            new Vector3(-13f, Random.Range(rangeYForegroundClouds[0], rangeYForegroundClouds[1]), cloudForeground.GetComponent<Transform>().position.z),
            cloudForeground.GetComponent<Transform>().rotation
        );
        cloudClone.GetComponent<ScrollScript>().speed = Random.Range(rangeSpeedForeground[0], rangeSpeedForeground[1]);
        cloudClone.GetComponent<Transform>().parent = foregroundCloud.GetComponent<Transform>();

        cloudClone.GetComponent<CloudColorScript>().colors = colorsForeground;
        cloudClone.GetComponent<CloudColorScript>().sun = sun;
        cloudClone.GetComponent<CloudColorScript>().moon = moon;
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<CloudGradientScript>().alpha = alpha;
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<CloudGradientScript>().radius = radius;
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<CloudGradientScript>().sun = sun;

        float scale = Random.Range(rangeCloudForegroundScale[0], rangeCloudForegroundScale[1]);
        cloudClone.GetComponent<Transform>().localScale = new Vector3(scale, scale, 1f);

        int sprite = Random.Range(0, cloudForegroundSprites.Length / 2);
        cloudClone.GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().sprite = cloudForegroundSprites[sprite * 2];
        cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<SpriteRenderer>().sprite = cloudForegroundSprites[sprite * 2 + 1];

        int[] flipped = new int[2];
        for (int i = 0; i < 2; i++)
        {
            flipped[0] = (int)Random.Range(0, 2);
            flipped[1] = (int)Random.Range(0, 2);
        }
        if (flipped[0] == 1)
        {
            cloudClone.GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().flipX = true;
            cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<SpriteRenderer>().flipX = true;
        }
        if (flipped[1] == 1)
        {
            cloudClone.GetComponent<Transform>().Find("cloud").GetComponent<SpriteRenderer>().flipY = true;
            cloudClone.GetComponent<Transform>().Find("gradient").GetComponent<SpriteRenderer>().flipY = true;
        }

        yield return new WaitForSeconds(Random.Range(rangeTimeDiffForeground[0], rangeTimeDiffForeground[1]));

        spawnBackgroundClouds = true;

    }

}
