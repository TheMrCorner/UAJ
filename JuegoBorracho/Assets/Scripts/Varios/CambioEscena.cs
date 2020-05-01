using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour {
    public string Escena;

    void OnTriggerEnter2D(Collider2D other) // Entramos
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.LoadScene(Escena);
        }
    }
}
