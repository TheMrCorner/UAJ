using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeatmap : MonoBehaviour
{
    // Start is called before the first frame update

    Heatmap hm;


    public static GameObject projectionPlane;   //!< A static reference to the plane which is used to display a heatmap.

    public static int RED_THRESHOLD = 235;      //!< Red threshold.
    ///	Minimum alpha a point must have to be red.
    public static int GREEN_THRESHOLD = 200;    //!< Green threshold.
    ///	Minimum alpha a point must have to be green.
    public static int BLUE_THRESHOLD = 150;     //!< Blue threshold.	
    ///	Minimum alpha a point must have to be Blue.
    public static int MINIMUM_THRESHOLD = 100;  //!< Minimum threshold.	
    ///	Minimum alpha a point must have to be rendered at all.
    ///	

    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;


    public Texture2D tex;

    public int test;

    void Start()
    {
        hm = new Heatmap(500, 500, 10);

        hm.AddPoint(new Vector2(0, 0));
        hm.AddPoint(new Vector2(0, 0));
        hm.AddPoint(new Vector2(10, 10));
        hm.AddPoint(new Vector2(5, 5));
        hm.AddPoint(new Vector2(30, 30));
        hm.AddPoint(new Vector2(30, 30));

        hm.AddPoint(new Vector2(30, 30));
        hm.AddPoint(new Vector2(30, 30));
        hm.AddPoint(new Vector2(30, 30));



        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[3];
      



        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[1];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
      

        gradient.SetKeys(colorKey, alphaKey);

        // What's the color at the relative time 0.25 (25 %) ?
        Debug.Log(gradient.Evaluate(0.25f));

        tex = hm.GetImage(gradient);

        Rect rect = new Rect(new Vector2(0, 0), new Vector2(500, 500));

        Sprite sp = Sprite.Create(tex, rect, new Vector2(0, 0));


        gameObject.GetComponent<SpriteRenderer>().sprite = sp;


    }

    public static Color[] Colorize(Color[] pixels)
    {
        for (int i = 0; i < pixels.Length; i++)
        {

            float r = 0, g = 0, b = 0, tmp = 0;
            pixels[i] *= 255f;

            float alpha = pixels[i].a;

            if (alpha == 0)
            {
                continue;
            }

            if (alpha <= 255 && alpha >= RED_THRESHOLD)
            {
                tmp = 255 - alpha;
                r = 255 - tmp;
                g = tmp * 12f;
            }
            else if (alpha <= (RED_THRESHOLD - 1) && alpha >= GREEN_THRESHOLD)
            {
                tmp = (RED_THRESHOLD - 1) - alpha;
                r = 255 - (tmp * 8f);
                g = 255;
            }
            else if (alpha <= (GREEN_THRESHOLD - 1) && alpha >= BLUE_THRESHOLD)
            {
                tmp = (GREEN_THRESHOLD - 1) - alpha;
                g = 255;
                b = tmp * 5;
            }
            else if (alpha <= (BLUE_THRESHOLD - 1) && alpha >= MINIMUM_THRESHOLD)
            {
                tmp = (BLUE_THRESHOLD - 1) - alpha;
                g = 255 - (tmp * 5f);
                b = 255;
            }
            else
                b = 255;
            pixels[i] = new Color(r, g, b, alpha / 2f);
            pixels[i] = NormalizeColor(pixels[i]);
        }

        return pixels;
    }

    public static Color NormalizeColor(Color col)
    {
        return new Color(col.r / 255f, col.g / 255f, col.b / 255f, col.a / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
