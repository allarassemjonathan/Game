using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    System.Random _rand;
    TagList tagList;
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
    public Text Inventory_text;
    public AudioClip crying;

    List<GameObject> _prefabs;
    List<GameObject> bbies;
    List<string> inventory;
    List<string> _inmap;
    Dictionary<GameObject, bool> mapping;
    static Dictionary<string, string> _heirs;
 
    const int _num_bby = 8;
    float dice;

    AudioSource source;

    void Start()
    {
        mapping = new Dictionary<GameObject, bool>();
        source = gameObject.GetComponent<AudioSource>();
        bbies = new List<GameObject>();
        inventory = new List<string>();
        tagList = new TagList();
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

        _heirs = new Dictionary<string, string>();
        _heirs.Add("piano", "note");
        _heirs.Add("plant", "cannabis");
        _heirs.Add("table", "bottle");
        _heirs.Add("crib", "binky");
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
        if (_rand.Next(100) == 0)
        {
         
        }
    }
    //generate items after collision with objects
    public void GenerateItems(GameObject item)
    {
        bool in_ = false;
        string val = "";

        // Looking up which object is provided by this collision
        if (item.tag.Equals(tagList.tagPiano))
        {
            val = tagList.tagNote;
        }
        else if (item.tag.Equals(tagList.tagTable))
        {
            val = tagList.tagBottle;
        }
        else if (item.tag.Equals(tagList.tagCrib))
        {
            val = tagList.tagBinky;
        }
        else if(item.tag.Equals(tagList.tagPlant))
        {
            val = tagList.tagDrug;
        }
        print("debugg1");
        print(item.tag);
        print(val);
        print("debugg bool" + in_);
        // check if we have any already that object
        for(int k =0; k < _inmap.Count; k++)
        {
            if (_inmap[k].Equals(val))
            {
                in_ = true;
            }
        }
        
        //if we have it do nothing otherwise generate it
        //if (!in_)
        //{
        print("debugg here " + item.name);
        GameObject temp = null;
            
            if (item.tag.Equals(tagList.tagPiano))
            {
            print("debugg here");
                temp = _Prefab_note;
            }
            else if (item.tag.Equals(tagList.tagTable))
            {
                temp = _Prefab_bottle;
            }
            else if (item.tag.Equals(tagList.tagCrib))
            {
                temp = _Prefab_binky;
            }
            else if (item.tag.Equals(tagList.tagPlant))
            {
                temp = _Prefab_drugs;
            }
            int radius = _rand.Next(5);
            while (radius < 1)
            {
                radius = _rand.Next(5);
            }
            print("debugg2");
            int i = _rand.Next(_prefabs.Count);
            GameObject _note = Instantiate(temp, new Vector2(item.transform.position.x + radius, item.transform.position.y + radius), Quaternion.identity);
            _inmap.Add(temp.name);
        //}
    }
    public void UpdateInventory(GameObject item)
    {
        bool diff = true;
        //if the item is not in the inventory
        for(int i = 0; i < inventory.Count; i++)
        {
            diff &= !item.name.Equals(inventory[i]);
        }
        if (diff)
        {
            string name = item.name;
            this.inventory.Add(name);
            string temp = "inventory\n";
            for (int i = 0; i < inventory.Count; i++)
            {
                temp = temp + (char)(i + 65) + " " + inventory[i].Substring(0, inventory[i].Length - 7) + "\n";
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
