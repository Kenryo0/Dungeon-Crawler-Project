using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    PlayerInventory playerInventory;

    // NearView()
    float distance;

    private void Start()
    {
        playerInventory = FindFirstObjectByType<PlayerInventory>(); // key will get up and it will saved in "inventary"
    }

    void Update()
    {
        if ( NearView() && Input.GetKeyDown(KeyCode.E) )
        {
            print("Je suis assez proche et je ramasse la clé");
            playerInventory.hasKey = true;
            Destroy(gameObject);
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (distance < 2f) return true;
        else return false;
    }
}
