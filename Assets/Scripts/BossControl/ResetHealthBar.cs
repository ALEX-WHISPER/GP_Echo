using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHealthBar : MonoBehaviour {
    public Vector3 startScale = new Vector3(0, 5, 1);
    public Vector3 endScale = new Vector3(12, 5, 1);
    public float duration = 1f;
    public float delay = 0f;

    private bool ifDone = false;

    void Start()
    {
        Vector3 startScaleValue = startScale;
        transform.localScale = startScaleValue;

        Invoke("TweenScaleTransform", delay);
    }

    void Update()
    {
        if (transform.localScale.x >= endScale.x)
        {
            transform.localScale = endScale;
            this.enabled = false;
            return;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.green, Color.red, Mathf.Abs(transform.localScale.x / endScale.x - 1));
        }
    }

    void TweenScaleTransform()
    {
        TweenScale scaleControl = gameObject.AddComponent<TweenScale>();
        scaleControl.from = startScale;
        scaleControl.to = endScale;
        scaleControl.duration = duration;
    }
}
