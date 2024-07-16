using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControl : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().material.SetTextureOffset("_MainTex", new Vector2(0, Time.time / 5));
    }
}

