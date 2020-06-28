using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HeatmapMenu : MonoBehaviour
{
    static string[] eventTypes = { "PlayerSword" , "PlayerShoots", "PlayerDeath", "InitLevel", "ChangeState",
                             "EnemyDeath", "EndLevel", "PlayerDash", "Damaged"};

    static private Heatmap _heatmap;

    static void Init()
    {
        _heatmap = FindObjectOfType<Heatmap>();
    }

    // creates every available heatmap
    //[MenuItem("Heatmaps/Generate All Heatmaps")]
    public static void GenerateAllHeatmaps()
    {
        //Init();
        //for (int i = 0; i < eventTypes.Length; i++)
        //{
        //    _heatmap.GenerateHeatmap(eventTypes[i]);

        //}
        Debug.LogError("Generate all heatmaps doesn't work, must use separated ones");
        
    }

    [MenuItem("Heatmaps/Generate Type.../ Damaged")]
    private static void GenerateDamagedHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("Damaged");
        print("Finished Generating Heatmap Damaged");
    }
    

    [MenuItem("Heatmaps/Generate Type.../ PlayerSword")]
    private static void GeneratePlayerSwordHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("PlayerSword");
        print("Finished Generating Heatmap PlayerSword");
    }
    

    [MenuItem("Heatmaps/Generate Type.../ PlayerShoots")]
    private static void GeneratePlayerShootsHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("PlayerShoots");
        print("Finished Generating Heatmap PlayerShoots");
    }


    [MenuItem("Heatmaps/Generate Type.../ PlayerDash")]
    private static void GeneratePlayerDashHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("PlayerDash");
        print("Finished Generating Heatmap PlayerDash");
    }


    [MenuItem("Heatmaps/Generate Type.../ PlayerDeath")]
    private static void GeneratePlayerDeathHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("PlayerDeath");
        print("Finished Generating Heatmap PlayerDeath");
    }
    

    [MenuItem("Heatmaps/Generate Type.../ ChangeState")]
    private static void GenerateChangeStateHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("ChangeState");
        print("Finished Generating Heatmap ChangeState");
    }
    

    [MenuItem("Heatmaps/Generate Type.../ EnemyDeath")]
    private static void GenerateEnemyDeathHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("EnemyDeath");
        print("Finished Generating Heatmap EnemyDeath");
    }


    [MenuItem("Heatmaps/Generate Type.../ InitLevel")]
    private static void GenerateInitLevelHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("InitLevel");
        print("Finished Generating Heatmap InitLevel");
    }


    [MenuItem("Heatmaps/Generate Type.../ EndLevel")]
    private static void GenerateEndLevelHeatmap()
    {
        Init();
        _heatmap.GenerateHeatmap("EndLevel");
        print("Finished Generating Heatmap EndLevel");
    }
}
