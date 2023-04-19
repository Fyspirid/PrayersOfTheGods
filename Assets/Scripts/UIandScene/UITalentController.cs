using UnityEngine;
using UnityEngine.UI;

public class UITalentController : MonoBehaviour
{
    public Button blue;
    public Button red;
    public Button violet;

    private GameManager gamesManager;

    private void Awake()
    {
        gamesManager = FindObjectOfType<GameManager>();
    }
    public void OnBlueButton()
    {
        if (gamesManager.electedSouls > 0)
        {
            SetInteractable(red, false);
            SetInteractable(violet, false);
        }
        else
        {
            SetInteractable(blue, false);
            SetInteractable(red, false);
            SetInteractable(violet, false);
        }
    }
    public void OnRedButton()
    {
        if (gamesManager.electedSouls > 0)
        {
            SetInteractable(blue, false);
            SetInteractable(violet, false);
        }
        else
        {
            SetInteractable(blue, false);
            SetInteractable(red, false);
            SetInteractable(violet, false);
        }
    }
    public void OnVioletButton()
    {
        if (gamesManager.electedSouls > 0)
        {
            SetInteractable(blue, false);
            SetInteractable(red, false);
        }
        else
        {
            SetInteractable(blue, false);
            SetInteractable(red, false);
            SetInteractable(violet, false);
        }
    }
    private void SetInteractable(Button button, bool interactable)
    {
        Selectable selectable = button.GetComponent<Selectable>();
        if (selectable != null)
        {
            selectable.interactable = interactable;
        }
    }
}
