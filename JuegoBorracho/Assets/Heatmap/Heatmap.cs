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


        Dictionary<string, List<Vector3>> data = new Dictionary<string, List<Vector3>>();

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
}
