using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using TMPro;

public class pizzamaker : MonoBehaviour, IInputClickHandler
{

    public GameObject tomato;
    //public GameObject redpepper;
    //public GameObject greenpepper;
    //public GameObject mushroom;
    //public GameObject pepperoni;
    //public GameObject olive;
    //public GameObject onion;
    
   

    //public Image myImage;
    //public string myString;
    //public float fadeTime;
    //public bool displayInfo;
    //public Text myText;
    //public Sprite mySprite;
    
    //public Canvas myCanvas;
    
	// Use this for initialization
	void Start () {
        //tomato = GameObject.Find("tomato");
        /*redpepper = GameObject.Find("redpepper");
        greenpepper = GameObject.Find("greenpepper");
        */

        
        GameObject.Find("nutrition_facts").GetComponent<SpriteRenderer>().color = Color.clear;
        //GameObject.Find("pepper_nf").GetComponent<SpriteRenderer>().color = Color.clear;
        //GameObject.Find("tomato_nf").GetComponent<SpriteRenderer>().color = Color.clear;
    }
	
	// Update is called once per frame
	public void Update () {
     
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //GameObject.Find("nutrition_facts").GetComponent<SpriteRenderer>().color = Color.white;
        tomato.transform.localScale += 0.5f * tomato.transform.localScale;

        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }

    /*void OnMouseOver()
    {
        
        GameObject.Find("nutrition_facts").GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseExit()
    {
        //Debug.Log("mouse not over object");
        //myText.color = Color.clear;
        //displayInfo = false;
        //GetComponent<SpriteRenderer>().enabled = false;
        //gameObject.GetComponent<Renderer>().enabled = false;

        GameObject.Find("nutrition_facts").GetComponent<SpriteRenderer>().color = Color.clear;
    }*/
    
  

}
