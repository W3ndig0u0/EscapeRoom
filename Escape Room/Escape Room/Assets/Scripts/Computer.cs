using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject appSquare;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject startButton;
    private bool appSquareActive = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Check if UI button is touched
            if (EventSystem.current.IsPointerOverGameObject() || IsTouchOverUIObject())
            {
                Debug.Log("EXIT!");
                appSquareActive = !appSquareActive;
                return;
            }

            Debug.Log("Start!");

            appSquareActive = !appSquareActive;
            appSquare.SetActive(appSquareActive);
            startButton.SetActive(!appSquareActive);
        }
    }

    private bool IsTouchOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
