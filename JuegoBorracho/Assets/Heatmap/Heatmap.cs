using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Clase Heatmap creada a partir del enlace https://answers.unity.com/questions/1078076/heat-map-effect.html
 */
public class KarlHeatmap
{
    private float[] samples;
    private float[] circle;
    private int width;
    private int height;
    private int radius;

    // returns the highest sample
    private float MaxValue
    {
        get
        {
            float v = 0f;
            for (int i = 0; i < samples.Length; i++)
                if (samples[i] > v)
                    v = samples[i];
            return v;
        }
    }

    public KarlHeatmap(int aWidth, int aHeight, int aRadius)
    {
        width = aWidth;
        height = aHeight;
        radius = aRadius;
        samples = new float[aWidth * aHeight];
        CreateCircleMap();
    }
    // creates our circle map that is "copied" into our map
    void CreateCircleMap()
    {
        circle = new float[radius * radius * 4];
        for (int x = -radius; x < radius; x++)
        {
            for (int y = -radius; y < radius; y++)
            {
                float l = (x * x + y * y) / (float)(radius * radius);
                float v = 0f;
                if (l < 1f)
                    v = 1f - l;
                circle[x + radius + radius * 2 * y] = v;
            }
        }
    }
    public void AddPoint(Vector2 aPos)
    {
        int px = Mathf.RoundToInt(aPos.x);
        int py = Mathf.RoundToInt(aPos.y);
        for (int x = -radius; x < radius; x++)
        {
            for (int y = -radius; y < radius; y++)
            {
                int ix = px + x;
                int iy = py + y;
                if (ix < 0 || iy < 0 || ix >= width || iy >= height)
                    continue;
                samples[ix + iy * width] += circle[x + radius + radius * 2 * y];
            }
        }
    }

    public Texture2D GetImage(Gradient aGradient)
    {
        Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
        float scale = 1f / MaxValue;
        Color[] colors = new Color[samples.Length];
        for (int i = 0; i < colors.Length; i++)
            colors[i] = aGradient.Evaluate(samples[i] * scale);
        tex.SetPixels(colors);
        tex.Apply();
        return tex;
    }
}
