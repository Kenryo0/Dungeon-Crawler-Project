using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public BoxCollider endCollider;
    public GameObject player;
    public List<GameObject> endCanvas;
    public Camera uiCamera;


    private void OnTriggerEnter(Collider other)
    {
        print("Trigger collision");
        
        Play();

    }

    public void Play()
    {
        foreach (GameObject menu in endCanvas)
        {
            menu.SetActive(true);
            player.SetActive(false);
            uiCamera.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
