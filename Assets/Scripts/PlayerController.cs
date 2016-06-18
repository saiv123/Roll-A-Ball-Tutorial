using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody objectRigidBody;
    private int pickUpsCollected;

    void Start ()
    {
        objectRigidBody = GetComponent<Rigidbody>();
        pickUpsCollected = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        objectRigidBody.AddForce(movement * speed);
         
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pickUpsCollected += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + pickUpsCollected.ToString();
        if (pickUpsCollected >= 13)
        {
            winText.text = "You Win!!";
        }
    }
}
