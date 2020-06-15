using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;



/*
 * Clase Heatmap basada en.............
 */
public class Heatmap : MonoBehaviour
{

    string resultsPath = "Telemetry/Results/";

    /*
     * 1. Leer los world points de los eventos.
     * 2. (Trasladar los valores para concordar con la imagen del mapa).
     * 3. Pasar los datos a un array de Vector3 por cada punto.
     * 4. Crear el heatmap pasándole los valores y la cámara concreta (usando las funciones de Karl).
     */
    private void Start()
    {
        TransformPoints();
    }


    private void TransformPoints()
    {
        string path = Application.dataPath + "/Telemetry/Results/";

        // Obiene array de archivos json en la pcarpeta dada
        string[] files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);


        List<JSONArray> jsonObjects;

        foreach (string file in files)
        {
            string jsonString = File.ReadAllText(file);
            JSONArray json = (JSONArray)JSON.Parse(jsonString);
        }


    }
}
