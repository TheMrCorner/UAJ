﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;



/*
 * Clase Heatmap adaptada de "https://github.com/karl-/unity-heatmap"
 */
public class Heatmap : MonoBehaviour
{
    public Camera heatmapCamera;
    private Camera mainCamera;

    public string shownEvent = "Damaged";
    [Range(1, 50)]
    public int accuracyRadio = 2;
    string screenshotPath = "/Heatmap/Results/Heatmap0.png";

    string resultsPath = "Telemetry/Results/";

    Dictionary<string, List<Vector3>> data;

    /*
     * 1. Leer los world points de los eventos.
     * 2. (Trasladar los valores para concordar con la imagen del mapa).
     * 3. Pasar los datos a un array de Vector3 por cada punto.
     * 4. Crear el heatmap pasándole los valores y la cámara concreta (usando las funciones de Karl).
     */


    private void Start()
    {
        mainCamera = Camera.main;
        data = new Dictionary<string, List<Vector3>>();
        SaveHeatmap();
        TransformPoints();
        FillHeatmap();
    }


    private void TransformPoints()
    {
        string path = Application.dataPath + "/Telemetry/Results/";

        // 1) Obtiene array de archivos json en la carpeta dada
        string[] files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);


        // 2) Parsea a JSON los archivos con los datos 
        List<JSONArray> jsonObjects = new List<JSONArray>();

        foreach (string file in files)
        {
            string jsonString = File.ReadAllText(file);
            JSONArray json = (JSONArray)JSON.Parse(jsonString);
            jsonObjects.Add(json);
        }

        // 3) Añade al diccionario las coordenadas de cada uno, agrupándolos por tipo de evento.
        foreach(JSONArray json in jsonObjects)
            foreach (JSONObject obj in json)
            {

             // a) Obtiene el tipo de evento y sus coordenadas
             object[] keys = obj.GetKeys().ToArray();
             string name = keys[0].ToString();
                
            float x = obj[name]["Position"]["x"];
            float y = obj[name]["Position"]["y"];

            Vector3 eventCoords = new Vector3(x, y, 0);

            Debug.Log("NAME: " + name);
            Debug.Log("COORDS: " + eventCoords);

            // a) Si aún no existe en el diccionario dicho evento, entonces se crea una nueva entrada
            if (!data.ContainsKey(name))
            {
                List<Vector3> coords = new List<Vector3>();
                data.Add(name, coords);
            }

            // b) Luego, simplemente se añaden las nuevas coordenadas a la lista en concreto
            data[name].Add(eventCoords);
        }


    }

    private void FillHeatmap()
    {
        if (data != null && data[shownEvent] != null)
        {
            Texture2D heatmapImage = KarlHeatmap.CreateHeatmap(data[shownEvent].ToArray(), heatmapCamera, accuracyRadio);
            KarlHeatmap.CreateRenderPlane(heatmapImage, heatmapCamera);
        }
        else
            Debug.LogError("data list error, error on event " + shownEvent);
    }

    private void SaveHeatmap()
    {
        string auxPath = screenshotPath;
        foreach (Camera c in Camera.allCameras)
            c.enabled = false;

        mainCamera.enabled = false;
        heatmapCamera.enabled = true;
        heatmapCamera.tag = "MainCamera";
        mainCamera.tag = "uwu";

        auxPath = Application.dataPath + auxPath;

        int i = 0;
        while (System.IO.File.Exists(auxPath))
            auxPath = auxPath.Replace("Heatmap"+i+".png", "Heatmap" + ++i + ".png");

        ScreenCapture.CaptureScreenshot(auxPath, 50);
    }

    private void OnValidate()
    {
        FillHeatmap();
    }
}
