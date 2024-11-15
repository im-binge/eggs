using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBrain : MonoBehaviour
{
    ChickenManager chickenManager;
    Rigidbody rb;
    Vector3 position;
    
    

    // Start is called before the first frame update
    void Start()
    {
        chickenManager = FindObjectOfType<ChickenManager>();

        position = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0f,0f,10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ChickenDestroyer")
        {
            chickenManager.Score();
            gameObject.transform.position = position;
            gameObject.SetActive(false);
        }
    }
}
