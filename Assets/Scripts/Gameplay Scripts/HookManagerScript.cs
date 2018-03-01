using UnityEngine;
using UnityEngine.UI;

public class HookManagerScript : MonoBehaviour {

    public int numberOfHooksActive;
    public int[] baitOrder;
    public GameObject fishes;
    public Sprite[] fishSprites;
    public GameoverScript gameOverScript;
    public float[] gravity;
    public float[] speedVertical;
    public float[] speedHorizontal;
    public float[] startWaits;
    public GameObject baitMain;
    public Sprite[] baits;
    public int[] baitInitCount;
    public Transform[] hookPositions;
    public float[] radius;
    public GameObject[] hooks;
    public int hooksActive;
    public int numberOfFishesActive;

    public bool setup;
    public bool hasSetup;
    private int i;
    private Sprite[] fishSprite;

    private ObjectPooler objectPooler;
    //private int baitsInstantiated;

	// Use this for initialization
	void Start () {

        setup = false;
        hasSetup = false;
        //baitsInstantiated = 0;
        objectPooler = ObjectPooler.Instance;

	}
	
	// Update is called once per frame
	void Update () {

        if (BaitSelectionScript.hasStarted && !hasSetup)
        {
            setup = true;
            BaitSelectionScript.hasStarted = false;
        }
		
        if (setup)
        {

            setup = false;
            //baitsInstantiated = 0;

            for (i = 0; i < hooks.Length; i++)
            {
                if (i <= numberOfHooksActive - 1)
                {
                    GameObject bait;
                    if (baitOrder[i] - 1 >= 0)
                    {
                        hooks[i].SetActive(true);
                        FishSpawnScript fishSpawnScript = hooks[i].GetComponent<FishSpawnScript>();
                        fishSpawnScript.enabled = true;
                        fishSpawnScript.fishSprite = fishSprites[baitOrder[i] - 1];
                        fishSpawnScript.fish = fishes;
                        fishSpawnScript.fishNumber = baitOrder[i] - 1;
                        fishSpawnScript.gravityScale = gravity[baitOrder[i] - 1];
                        fishSpawnScript.speedHorizontal = speedHorizontal[baitOrder[i] - 1];
                        fishSpawnScript.speedVertical = speedVertical[baitOrder[i] - 1];
                        bait = objectPooler.SpawnFromPool(
                            StringConsants.stringBaits,
                            hooks[i].GetComponent<Transform>().Find("baitSpawnPoint").GetComponent<Transform>().position,
                            baitMain.GetComponent<Transform>().rotation
                        );
                        bait.GetComponent<SpriteRenderer>().sprite = baits[baitOrder[i] - 1];
                        bait.GetComponent<BaitScript>().baitNum = baitOrder[i] - 1;
                        bait.GetComponent<BaitScript>().initialCount = baitInitCount[i];
                        bait.GetComponent<Transform>().parent = hooks[i].GetComponent<Transform>();
                        bait.GetComponent<BaitScript>().baitNumber = hooks[i].GetComponent<Transform>().Find("Canvas").GetComponent<Transform>().Find("Text").GetComponent<Text>();
                        hooks[i].GetComponent<Transform>().Find("Canvas").GetComponent<Transform>().Find("Text").GetComponent<Text>().enabled = true;
                        fishSpawnScript.baitScript = bait.GetComponent<BaitScript>();
                        bait.GetComponent<BaitScript>().enabled = true;
                        fishSpawnScript.StartCoroutine(fishSpawnScript.StartWait());
                        //baitsInstantiated++;
                    } else
                    {
                        hooks[i].SetActive(true);
                        hooks[i].GetComponent<FishSpawnScript>().enabled = false;
                        hooks[i].GetComponent<Transform>().Find("Canvas").GetComponent<Transform>().Find("Text").GetComponent<Text>().enabled = false;
                    }
                }
                else
                {
                    hooks[i].SetActive(false);
                }
            }

            switch (numberOfHooksActive)
            {

                case 1:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[0].position.x, 
                            hooks[0].GetComponent<Transform>().position.y, 
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[0];

                    } break;

                case 2:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[1].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[1];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[2].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[1];


                    } break;

                case 3:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[3].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[2];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[4].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[2];


                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[5].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[2].GetComponent<FishSpawnScript>().radius = radius[2];


                    } break;

                case 4:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[6].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[3];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[7].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[3];


                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[8].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[2].GetComponent<FishSpawnScript>().radius = radius[3];


                        hooks[3].GetComponent<Transform>().position = new Vector3(
                            hookPositions[9].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[3].GetComponent<FishSpawnScript>().radius = radius[3];


                    } break;

                case 5:
                    {

                        hooks[0].GetComponent<Transform>().position = new Vector3(
                            hookPositions[10].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[0].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[1].GetComponent<Transform>().position = new Vector3(
                            hookPositions[11].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[1].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[2].GetComponent<Transform>().position = new Vector3(
                            hookPositions[12].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[2].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[3].GetComponent<Transform>().position = new Vector3(
                            hookPositions[13].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[3].GetComponent<FishSpawnScript>().radius = radius[4];


                        hooks[4].GetComponent<Transform>().position = new Vector3(
                            hookPositions[14].position.x,
                            hooks[0].GetComponent<Transform>().position.y,
                            hooks[0].GetComponent<Transform>().position.z
                        );

                        hooks[4].GetComponent<FishSpawnScript>().radius = radius[4];


                    }
                    break;

            }

            hasSetup = true;

            gameOverScript.enabled = true;

        }

    }
}
