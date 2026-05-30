using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public static bool IsEnemyReached=false;

}
public enum Towers
{
    Turret, Cannon, Crystal, Catapult, Ballista
}
public enum Enemies 
{
    normalufo,weaponedufo
}


