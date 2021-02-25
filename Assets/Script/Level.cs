
using UnityEngine;

public class Level : MonoBehaviour
{
    static int level = 51;

    public static int GetLevel()
    {
        return level;
    }

    public static int NextLevel()
    {
        return level++;
    }

}
