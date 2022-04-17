using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image MiddleBar, UpBar;
    private float startHealth = 100f;

    public void HealthBarUpdate(float fixedHealth)
    {
        StartCoroutine(UpdateHealthBar(fixedHealth));
    }

    private IEnumerator UpdateHealthBar(float fixedHealth)
    {
        float lastHealth = UpBar.fillAmount;

        for (float t = 0; t < 1; t += Time.deltaTime / 0.2f)
        {
            UpBar.fillAmount = Mathf.Lerp(lastHealth, fixedHealth / startHealth, t);
            yield return null;
        }
        for (float t = 0; t < 1; t += Time.deltaTime / 0.4f)
        {
            MiddleBar.fillAmount = Mathf.Lerp(lastHealth, fixedHealth / startHealth, t);
            yield return null;
        }
        UpBar.fillAmount = fixedHealth / startHealth;
        MiddleBar.fillAmount = fixedHealth / startHealth;
    }
}
