using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameSession : MonoBehaviour
{
    public float sessionTime = 10f;
    private const string GAME_SELECTION_SCENE = "GameSelectionScene";
    private Vector3 startPos;

    public new Light light;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject pauseCanvas;
    public GameObject instructionsCanvas;
    public XRController leftController;
    public XRController rightController;

    private bool isPaused = false;
    private float currentTime = 0f;

    void Start()
    {
        currentTime = sessionTime;
        startPos = transform.position;
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    void Update()
    {
        if (!isPaused) {
            currentTime -= 1 * Time.deltaTime;
            AdjustLightIntensity();
        }

        if (currentTime < 0)
        {
            HandleSessionEnd(false);
        }

    }

    private void HandleSessionEnd(bool success)
    {
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);

        GameObject canvas = success ? winCanvas : loseCanvas;

        ShowCanvasToUser(canvas);
    }

    private void AdjustLightIntensity()
    {
        const float upperbound = 2.3f;
        const float lowerbound = 0.3f;
        float intensityValue = lowerbound + ((upperbound - lowerbound) * (currentTime / sessionTime));
        light.intensity = Mathf.Max(lowerbound, intensityValue);
    }

    private void ShowCanvasToUser(GameObject canvas)
    {
        Vector3 newPos = Camera.main.transform.position + Camera.main.transform.forward * 2;
        newPos.y += 0.3f;
        canvas.transform.position = newPos;
        canvas.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);

        canvas.SetActive(true);
    }

    private void HideCanvasFromUser(GameObject canvas) {
        canvas.transform.position = startPos;
        canvas.SetActive(false);
    }

    public void WinGame()
    {
        HandleSessionEnd(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(GAME_SELECTION_SCENE);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void PauseButtonPressed() {
        isPaused = !isPaused;
        if (isPaused) {
            ShowCanvasToUser(pauseCanvas);
            HideCanvasFromUser(instructionsCanvas);
        } else {
            HideCanvasFromUser(pauseCanvas);
            HideCanvasFromUser(instructionsCanvas);
        }

    }

    public void ShowInstructions() {
        HideCanvasFromUser(pauseCanvas);
        ShowCanvasToUser(instructionsCanvas);
    }

    public void ShowPauseMenu() {
        HideCanvasFromUser(instructionsCanvas);
        ShowCanvasToUser(pauseCanvas);
    }
    
}