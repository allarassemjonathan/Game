using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject _Prefab_note;
    public GameObject _Prefab_bottle;
    public GameObject _Prefab_binky;
    public GameObject _Prefab_drugs;
    List<GameObject> _prefabs;

    public Text Inventory_text;
    List<GameObject> inventory;
    AudioSource source;
    public AudioClip crying;
    System.Random _rand;
    const int _num_bby = 8;
    float dice;
    List<GameObject> bbies;
    Dictionary<GameObject, bool> mapping;
    void Start()
    {
        mapping = new Dictionary<GameObject, bool>();
        source = gameObject.GetComponent<AudioSource>();
        bbies = new List<GameObject>();
        inventory = new List<GameObject>();

        _prefabs = new List<GameObject>();
        _prefabs.Add(_Prefab_note);
        _prefabs.Add(_Prefab_drugs);
        _prefabs.Add(_Prefab_bottle);
        _prefabs.Add(_Prefab_binky);

        _rand = new System.Random();
        bbies.Add(_baby_1);
        bbies.Add(_baby_2);
        bbies.Add(_baby_3);
        bbies.Add(_baby_4);
        bbies.Add(_baby_5);
        bbies.Add(_baby_6);
        bbies.Add(_baby_7);
        bbies.Add(_baby_8);
    }

    // Update is called once per frame
    void Update()
    {
        //if (_rand.Next(1000) == 0)
        //{
        //   SetMapping(_num_bby);
        //  print("HEYYY");
        //}
        //UpdateInventory(_Prefab_note);
    }

    private void FixedUpdate()
    {
        if (_rand.Next(50) == 0)
        {
            float x = (float)_rand.Next(-10, 10);
            float y = (float)_rand.Next(-10, 10);
            int i = _rand.Next(_prefabs.Count);
            GameObject _note = Instantiate(_prefabs[i], new Vector2(x, y), Quaternion.identity);

        }
    }

    public void UpdateInventory(GameObject item)
    {
        bool diff = true;
        for(int i = 0; i < inventory.Count; i++)
        {
            diff &= !item.name.Equals(inventory[i].name);
        }
        if (diff)
        {
            this.inventory.Add(item);
            string temp = "inventory\n";
            for (int i = 0; i < inventory.Count; i++)
            {
                temp = temp + (char)(i + 65) + " " + inventory[i].name.Substring(0, inventory[i].name.Length - 7) + "\n";
            }
            Inventory_text.text = temp;
            Destroy(item);
        }

    }
    //initializing the mapping
    void SetMapping(int num_babies)
    {

        for (int i = 0; i < _num_bby; i++)
        {
            bool temp;
            dice = Random.value;
            if (dice > .5)
            {
                temp = true;
            }
            else
            {
                temp = false;
            }
            if (temp != mapping[bbies[i]])
            {
                mapping.Add(bbies[i], temp);
                if (temp)
                {
                    source.PlayOneShot(crying);
                }
            }
           
        }

        
    }
}
