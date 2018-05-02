using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // Use this for initialization
    void Awake()
    {
        Instance = this;

        GameObject.Find("nutrition_facts_tomato").GetComponent<SpriteRenderer>().color = Color.clear;
        GameObject.Find("redpepper_facts").GetComponent<SpriteRenderer>().color = Color.clear;
        GameObject.Find("greenpepper_facts").GetComponent<SpriteRenderer>().color = Color.clear;
        GameObject.Find("olive_facts").GetComponent<SpriteRenderer>().color = Color.clear;
        GameObject.Find("onion_facts").GetComponent<SpriteRenderer>().color = Color.clear;
        GameObject.Find("pepperoni_facts").GetComponent<SpriteRenderer>().color = Color.clear;
        GameObject.Find("mushroom_facts").GetComponent<SpriteRenderer>().color = Color.clear;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
            if (FocusedObject.name == "tom")
            {
                GameObject.Find("nutrition_facts_tomato").GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (FocusedObject.name == "redpep")
            {
                GameObject.Find("redpepper_facts").GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (FocusedObject.name == "greenpep")
            {
                GameObject.Find("greenpepper_facts").GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (FocusedObject.name == "olive")
            {
                GameObject.Find("olive_facts").GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (FocusedObject.name == "onion")
            {
                GameObject.Find("onion_facts").GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (FocusedObject.name == "pepperoni")
            {
                GameObject.Find("pepperoni_facts").GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (FocusedObject.name == "mushroom")
            {
                GameObject.Find("mushroom_facts").GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            if (FocusedObject.name == "tom")
            {
                GameObject.Find("nutrition_facts_tomato").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else if (FocusedObject.name == "redpep")
            {
                GameObject.Find("redpepper_facts").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else if (FocusedObject.name == "greenpep")
            {
                GameObject.Find("greenpepper_facts").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else if (FocusedObject.name == "olive")
            {
                GameObject.Find("olive_facts").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else if (FocusedObject.name == "onion")
            {
                GameObject.Find("onion_facts").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else if (FocusedObject.name == "pepperoni")
            {
                GameObject.Find("pepperoni_facts").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            else if (FocusedObject.name == "mushroom")
            {
                GameObject.Find("mushroom_facts").GetComponent<SpriteRenderer>().color = Color.clear;
            }
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}