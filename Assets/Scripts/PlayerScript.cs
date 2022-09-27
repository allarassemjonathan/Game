using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    float speed = 5;
    Rigidbody2D _rgd;
    ManagerScript _manager;
    // Start is called before the first frame update
    void Start()
    {
        _rgd = gameObject.GetComponent<Rigidbody2D>();
        _manager =FindObjectOfType<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = speed * Input.GetAxis("Horizontal");
        float y = speed * Input.GetAxis("Vertical");
        _rgd.velocity = new Vector2(x, y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {   
                
        if  (collision.gameObject.tag.Equals("note")
            || collision.gameObject.tag.Equals("bottle")
            || collision.gameObject.tag.Equals("binky")
            || collision.gameObject.tag.Equals("cannabis"))
        {
            _manager.UpdateInventory(collision.gameObject);
        }
        else
        {
            _manager.GenerateItems(collision.gameObject);
        }
        }
        catch(Exception e)
        {
            print(e.Message);
        }

        
    }
}
