using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _baby_1;
    public GameObject _baby_2;
    public GameObject _baby_3;
    public GameObject _baby_4;
    public GameObject _baby_5;
    public GameObject _baby_6;
    public GameObject _baby_7;
    public GameObject _baby_8;
    Dictionary<GameObject, bool> mapping;
    void Start()
    {
        mapping = new Dictionary<GameObject, bool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
