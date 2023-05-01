using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugDisplay : MonoBehaviour
{
  public TextMeshProUGUI fpsText;             // Reference to the UI text component for displaying FPS
    public TextMeshProUGUI frameTimeText;       // Reference to the UI text component for displaying frame time
    public TextMeshProUGUI memoryUsageText;     // Reference to the UI text component for displaying memory usage
    public TextMeshProUGUI objectCountText;     // Reference to the UI text component for displaying object count
    public TextMeshProUGUI physicsText;         // Reference to the UI text component for displaying physics performance

    private float deltaTime;         // Time it takes to render a frame
    private int objectCount;         // Number of active objects in the scene
    private float lastPhysicsTime;   // Time physics calculations were last performed
    private float physicsInterval;   // Time between physics calculations
    private bool isPaused;           // Whether the game is currently paused

    private void Start()
    {
        // Set the target frame rate to 60 FPS
        Application.targetFrameRate = 60;

        // Initialize physics performance variables
        lastPhysicsTime = Time.time;
        physicsInterval = Time.fixedDeltaTime;
    }

    private void Update()
    {
        // Calculate the time it takes to render a frame
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // Calculate FPS and frame time
        float fps = 1.0f / deltaTime;
        float frameTime = deltaTime * 1000.0f;

        // Calculate memory usage
        long memoryUsage = System.GC.GetTotalMemory(false);

        // Update the object count
        objectCount = GameObject.FindObjectsOfType<GameObject>().Length;

        // Update the physics performance information
        if (Time.time - lastPhysicsTime > physicsInterval)
        {
            Physics.autoSimulation = false;
            Physics.Simulate(Time.time - lastPhysicsTime);
            Physics.autoSimulation = true;

            lastPhysicsTime = Time.time;
        }

        // Update the UI text components with the new information
        fpsText.SetText($"FPS: {fps:0.}") ;                                    // Round FPS to nearest whole number
        frameTimeText.SetText($"Frame Time: {frameTime:0.} ms") ;              // Round frame time to nearest whole number with "ms" suffix
        memoryUsageText.SetText($"Memory Usage: {memoryUsage / 1024} KB")  ;     // Convert memory usage from bytes to kilobytes
        objectCountText.SetText($"Object Count: {objectCount}")  ;
        physicsText.SetText($"Physics Calculations: {Time.fixedDeltaTime / Time.deltaTime:0.0}x")  ;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
