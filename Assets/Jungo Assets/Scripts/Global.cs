using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    // Global variable definitions
    public static int score = 0;

    public static void UpdateScore(int add)
    {
        score += add;
    }
}
