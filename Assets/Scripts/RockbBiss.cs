﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockbBiss : MonoBehaviour
{
    [SerializeField] float moveX=0.1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveX);
    }
}
