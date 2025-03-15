using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public static LevelUpMenu instance;


    private void Awake()
    {
        instance = this;
    }

    public GameObject levelUpMenuUI;
    //public Button Button1;
    //public Button Button2;
    //public Button Button3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BonusChoiceMenu()
    {
        Time.timeScale = 0f;
        levelUpMenuUI.SetActive(true);
        ButtonChoice(); // ICI BRYAN ET JEREMIAH
        levelUpMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ButtonChoice()
    {
        // ICI AUSSI BRYAN ET JEREMIAH
    }
}
