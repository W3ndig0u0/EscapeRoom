using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenWithKey : MonoBehaviour
{
    bool key;
    
    void Start()
    {
        bool key = PlayerPrefs.GetInt("HasKey", 0) == 1;
        this.gameObject.transform.localScale = new Vector3(1,1,1);
        Debug.Log(key);
        ShowButton();
    }

    void ShowButton(){
        if (!key) {
            this.gameObject.transform.localScale = new Vector3(0,0,0);
            this.gameObject.SetActive(false);
        }
        else if(key){
            this.gameObject.transform.localScale = new Vector3(1,1,1);
        }
    }
}
