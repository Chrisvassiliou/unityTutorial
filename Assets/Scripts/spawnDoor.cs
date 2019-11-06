using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoor : MonoBehaviour
{
    bool activated = false;
    public Transform spawnLocation;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && activated == false)
        {
            activated = true;
            Instantiate(door, spawnLocation.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
