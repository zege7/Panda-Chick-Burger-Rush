using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;
    private StoveCounter stoveCounter;

    private Color defaultColor;

    private void Start()
    {
        // Default color (CuttingCounter için sarý)
        defaultColor = barImage.color;

        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null)
        {
            Debug.LogError("Game Object" + hasProgressGameObject + "does not have a component that implements IHasProgress!");
            return;
        }
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        // StoveCounter varsa renk/state kontrolü yapýlacak
        stoveCounter = hasProgressGameObject.GetComponent<StoveCounter>();
        if (stoveCounter != null)
        {
            stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        }
        barImage.fillAmount = 0f;
        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if (e.progressNormalized==0f || e.progressNormalized==1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        switch (e.state)
        {
            case StoveCounter.State.Frying:
                barImage.color = defaultColor; // sarý
                break;

            case StoveCounter.State.Fried:
                barImage.color = Color.red; // burned'a giden süreç
                break;

            default:
                barImage.color = defaultColor;
                break;
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (hasProgress != null)
        {
            hasProgress.OnProgressChanged -= HasProgress_OnProgressChanged;
        }

        if (stoveCounter != null)
        {
            stoveCounter.OnStateChanged -= StoveCounter_OnStateChanged;
        }
    }
}
