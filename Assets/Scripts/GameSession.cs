using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private const float SESSION_TIME = 10f;
    private const string GAME_SELECTION_SCENE = "GameSelectionScene";

    public Light light;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject pauseCanvas;

    private bool isPaused = false;
    private float currentTime = 0f;

    void Start()
    {
        currentTime = SESSION_TIME;
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    void Update()
    {
        if (!isPaused)
        {
            currentTime -= 1 * Time.deltaTime;
            AdjustLightIntensity();
        }

        if (currentTime < 0)
        {
            handleSessionEnd(false);
        }

    }

    private void handleSessionEnd(bool success)
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
        float intensityValue = lowerbound + ((upperbound - lowerbound) * (currentTime / SESSION_TIME));
        light.intensity = Mathf.Max(lowerbound, intensityValue);
    }

    private void ShowCanvasToUser(GameObject canvas)
    {
        Vector3 newPos = Camera.main.transform.position + Camera.main.transform.forward * 2;
        newPos.y += 0.3f;
        canvas.transform.position = newPos;
        canvas.transform.rotation = Camera.main.transform.rotation;

        canvas.SetActive(true);
    }

    public void WinGame()
    {
        handleSessionEnd(true);
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

    public void TogglePause()
    {
        isPaused = !isPaused;
        ShowCanvasToUser(pauseCanvas);
    }


}
