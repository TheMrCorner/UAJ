﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivaColliderSalida : MonoBehaviour {

    public BoxCollider2D colliderPared;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            colliderPared.enabled = false;
    }
}
