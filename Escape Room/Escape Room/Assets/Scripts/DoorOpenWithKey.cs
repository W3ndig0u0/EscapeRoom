using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenWithKey : MonoBehaviour
{
    private bool hasKey = false;
    private bool key;

    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        ShowButton();
    }

    public void ShowButton()
    {
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            this.gameObject.SetActive(false);
        }
    }
}
