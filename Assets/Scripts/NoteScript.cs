using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    ManagerScript _manager;
    void Start()
    {
        _manager = FindObjectOfType<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _manager.UpdateInventory(gameObject);
        //Destroy(gameObject);
    }
}
