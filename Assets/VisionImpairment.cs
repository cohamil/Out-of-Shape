using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VisionImpairment : MonoBehaviour
{
    public Image blackBox; // Reference to the Panel's Image component
    public float blockDuration = 2.0f; // Time the box stays visible
    public float interval = 5.0f; // Time between block occurrences
    public float fadeDuration = 0.5f; // Duration of fade-in and fade-out

    private Coroutine blockRoutine;

    void Start()
    {
        if (blackBox == null)
        {
            Debug.LogError("Black box Image is not assigned!");
            return;
        }

        // Ensure the black box is fully transparent at the start
        SetAlpha(0f);

        // Start the routine
        blockRoutine = StartCoroutine(BlockVisionRoutine());
    }

    private IEnumerator BlockVisionRoutine()
    {
        while (true)
        {
            // Wait for the interval
            yield return new WaitForSeconds(interval);

            // Fade in the black box
            yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

            // Keep the black box visible for the blockDuration
            yield return new WaitForSeconds(blockDuration);

            // Fade out the black box
            yield return StartCoroutine(Fade(1f, 0f, fadeDuration));
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = blackBox.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            blackBox.color = color;
            yield return null;
        }

        // Ensure the final alpha is set
        color.a = endAlpha;
        blackBox.color = color;
    }

    private void SetAlpha(float alpha)
    {
        Color color = blackBox.color;
        color.a = alpha;
        blackBox.color = color;
    }
}
