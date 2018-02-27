using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringConsants : MonoBehaviour {

    public static string stringLargeIsland = "Large Island";

    public static string stringLightHouse = "Light House";

    public static string stringSeaArch = "Sea Arch";

    public static string stringRocks = "Rocks";

    public static string stringFrontRocks = "Front Rocks";

    public static string stringBackRocks = "Back Rocks";

    public static string stringCloudsBackground = "Clouds Background";

    public static string stringCloudsForeground = "Clouds Foreground";

    public static string stringBullets = "Bullets";

    public static string stringFishes = "Fishes";

    public static string stringCrabs = "Crabs";

    public static string stringMountains = "Mountains";

    public static string StringMapper(string name)
    {

        if (name.Substring(0, 10).Equals("Mountain 1"))
        {
            return stringMountains;
        }
        else if (name.Substring(0, 4) == "Rock")
        {
            return stringRocks;
        } 
        else if (name.Substring(0, 10) == "Front Rock")
        {
            return stringFrontRocks;
        }
        else if (name.Substring(0, 9) == "Back Rock")
        {
            return stringFrontRocks;
        } 
        else if (name.Substring(0, 16) == "Cloud Background")
        {
            return stringCloudsBackground;
        } 
        else if (name.Substring(0, 16) == "Cloud Foreground")
        {
            return stringCloudsForeground;
        }
        else
        {
            return null;
        }

    }

}
