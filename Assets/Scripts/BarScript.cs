using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform trans;
    float stime;
    float dtime;

    void Start()
    {
        trans = gameObject.GetComponent<RectTransform>();
        stime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        dtime = Time.time - stime;
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, trans.sizeDelta.y * dtime);
    }
}
