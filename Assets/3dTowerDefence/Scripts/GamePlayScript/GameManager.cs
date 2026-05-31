using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public static bool IsEnemyReached = false;

    public WaveSystemScript waveSystemScript;



    public void TowerPlacement()
    {

    }

    public void PlayGame()
    {
        StartCoroutine(waveSystemScript.SpawnWaves());
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
public enum TowerType
{
    Turret,
    Cannon,
    Crystal,
    Catapult,
    Ballist
}

public enum EnemyType
{
    NormalUFO,
    WeaponedUFO
}

public enum TowerSpot
{
    spot1,spot2,spot3,spot4,spot5,spot6
}

public enum TowerSpotType
{
    Locked,
    Available,
    Occupied
}



