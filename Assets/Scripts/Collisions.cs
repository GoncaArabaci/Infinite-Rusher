using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public GameObject player;
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //this.gameObject.GetComponent<MeshCollider>().enabled = false;
        //player.GetComponent<PlayerController>().enabled = true;
        //model.GetComponent<Animator>().Play("Stumble");
    }
}
