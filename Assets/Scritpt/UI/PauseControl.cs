using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField,Range(0, 0.9f)]
    private float pauseTimeScale = 0.1f;
    private bool IsTouching { get => Input.touchCount > 0; }
    private bool isPaused = false;
    void Update()
    {
        if (IsTouching || Input.GetMouseButton(0))
        {
            if (isPaused)
                StartCoroutine(DelayedResume());
        }
        else
        {
            if (!isPaused)
                PauseGame();
        }
    }
    private void PauseGame()
    {
        pauseScreen.SetActive(true);
        AjustTimeScale(pauseTimeScale);
        isPaused = true;
    }
    private void ResumeGame()
    {
        pauseScreen.SetActive(false);
        AjustTimeScale(1f);
        isPaused = false;
    }
    private IEnumerator DelayedResume()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        ResumeGame();
    }
    private void AjustTimeScale(float scale)
    {
        Time.timeScale = scale;
        Time.fixedDeltaTime = 0.02f * scale;
    }
}
