using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light mainLight;
    private Coroutine alertCoroutine;

    public void SetStealthMode()
    {
        StopAlert();
        mainLight.intensity = 0f;
        mainLight.color = new Color(0.4994659f, 0.6185013f, 0.7672955f);
    }

    public void SetNormalMode()
    {
        StopAlert();
        mainLight.intensity = 2f;
        mainLight.color = new Color(0.4994659f, 0.6185013f, 0.7672955f);
    }

    public void SetAlertMode()
    {
        StopAlert();
        mainLight.intensity = 1.5f;
        alertCoroutine = StartCoroutine(AlertCoroutine());
    }

    private void StopAlert()
    {
        if (alertCoroutine != null)
            StopCoroutine(alertCoroutine);
    }

    private IEnumerator AlertCoroutine()
    {
        while (true)
        {
            mainLight.color = Color.blue;
            yield return new WaitForSeconds(0.5f);

            mainLight.color = Color.red;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
