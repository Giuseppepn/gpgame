using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    CircleCollider2D cd;
    // Start is called before the first frame update
    void Start()
    {
        cd.GetComponent<CircleCollider2D>();

        if (cd == null)
        {
            Debug.LogError("Errore!");
            return;
        }

        StartCoroutine(SpawnAnimation());
    }


    IEnumerator SpawnAnimation()
    {
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + Vector3.up * 0.75f;

        float duration = 0.35f;
        float startTime = Time.time;


        while (Time.time < startTime + duration)
        {
            float animationProgress = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(originalPosition, targetPosition, animationProgress);
            yield return null;
        }

        transform.position = targetPosition;


        yield return new WaitForSeconds(0.1f);


        startTime = Time.time;
        duration = 0.35f;


        while (Time.time < startTime + duration)
        {
            float animationProgress = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(targetPosition, originalPosition, animationProgress);
            yield return null;
        }

        transform.position = originalPosition;
    }


}
