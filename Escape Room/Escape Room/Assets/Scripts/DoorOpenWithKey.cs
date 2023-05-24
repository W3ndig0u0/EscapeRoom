using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenWithKey : MonoBehaviour
{
    private bool hasKey = false;
    private bool key;

    void Start()
    {
        //key = PlayerPrefs.GetInt("HasKey", 0) == 1 ? true : false;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        ShowButton();
    }

    public void ShowButton()
    {
        Debug.Log(key);
        if (!key)
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            this.gameObject.SetActive(false);
        }
        else if (key)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void UpdateKey(bool newHasKey)
    {
        key = newHasKey;
    }
    public void TakeKey()
    {
        hasKey = true;
        //PlayerPrefs.SetInt("HasKey", hasKey ? 1 : 0);
        //PlayerPrefs.Save();
        UpdateKey(hasKey);
        Debug.Log("TAR NYCKELN");
    }

}
