using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [Tooltip("Plug follow this local EmptyObject")]
    public Transform PlayerHandsPosition;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    bool youCan = true, follow = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (youCan) Interaction();
    }

    void Interaction()
    {
        if (NearView() && Input.GetKeyDown(KeyCode.E) && !follow)
        {
            follow = true;
            rb.isKinematic = true;   //makes the rigidbody not be acted upon by forces
            transform.position = PlayerHandsPosition.transform.position; // sets the position of the object to your hand position
            transform.parent = PlayerHandsPosition.transform; //makes the object become a child of the parent so that it moves with the hands
        }
        else if (Input.GetKeyDown(KeyCode.F) && follow)
        {
            follow = false;
            print("Trigger condition");
            rb.isKinematic = false;
            transform.parent = null;
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 2f && angleView < 35f) return true;
        else return false;
    }
}
