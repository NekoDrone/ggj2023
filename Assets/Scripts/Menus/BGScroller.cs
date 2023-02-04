using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
    [SerializeField] private RawImage bgimg;
    [SerializeField] private float x_rate, y_rate;

    // Update is called once per frame
    void Update()
    {
        bgimg.uvRect = new Rect(bgimg.uvRect.position + new Vector2(x_rate, y_rate) * Time.deltaTime, bgimg.uvRect.size);
    }
}
