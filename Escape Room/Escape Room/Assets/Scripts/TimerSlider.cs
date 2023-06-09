using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
  public MemoryPuzzleGame memoryPuzzleGame;
  public float totalTime = 75; // total time in seconds
  private float timeLeft; // time left in seconds
  private Slider slider; // reference to the UI Slider component
  public VideoChoiseButton videoChoiseButton;
  private void Start()
  {
    slider = GetComponent<Slider>(); // get the Slider component attached to this object
    timeLeft = totalTime; // set the initial time left
    Debug.Log(slider);
  }

  private void Update()
  {
    if(timeLeft <= 0){
      GameOver();
      Destroy(gameObject);
      return;
    }

    timeLeft -= Time.deltaTime; // subtract the time since the last frame from time left
    slider.value = timeLeft; // set the value of the Slider based on the remaining time
  }

public void RefillSlider()
{
    timeLeft = totalTime;
    slider.value = totalTime;
}
public void GameOver()
  {
    memoryPuzzleGame.GameIsOver();
    videoChoiseButton.Replay();
    Destroy(gameObject);
  }
}