using System.Collections;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float _dissolveTime = 0.75f;
    public SpriteRenderer spriteRenderer;
    public Material material;

    private int _dissolveAmount = Shader.PropertyToID("_DissolveAmount");


    public void StartDissolve()
    {
        StartCoroutine(DoDissolve());
    }

    public void StartAppear()
    {
        StartCoroutine(DoAppear());
    }

    private IEnumerator DoDissolve()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime; // Increment elapsed time

            float lerpedDissolve = Mathf.Lerp(0f, 1f, (elapsedTime / _dissolveTime));

            material.SetFloat(_dissolveAmount, lerpedDissolve);

            yield return null; // Wait for the next frame
        }
    }

    private IEnumerator DoAppear()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime; // Increment elapsed time

            float lerpedDissolve = Mathf.Lerp(1f, 0f, (elapsedTime / _dissolveTime));

            material.SetFloat(_dissolveAmount, lerpedDissolve);

            yield return null; // Wait for the next frame
        }
    }
}
