using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour


    {
       [SerializeField] private GameObject appSquare;

       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Square clicked!");
        appSquare.SetActive(true);
        this.gameObject.SetActive(false);   
    }



    // Update is called once per frame
     private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Square touched!");
            appSquare.SetActive(true);
            this.gameObject.SetActive(false);   
        }
    }
}
