using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
  public float totalTime = 60f; // total time in seconds
  private float timeLeft; // time left in seconds
  private Slider slider; // reference to the UI Slider component

  private void Start()
  {
    slider = GetComponent<Slider>(); // get the Slider component attached to this object
    timeLeft = totalTime; // set the initial time left
    Debug.Log(slider);
  }

  private void Update()
  {
    timeLeft -= Time.deltaTime; // subtract the time since the last frame from time left
    slider.value = timeLeft; // set the value of the Slider based on the remaining time
    Debug.Log(slider.value);
  }
}