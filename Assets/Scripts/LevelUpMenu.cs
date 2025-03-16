using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public static LevelUpMenu instance;

    public int[] choices = new int[3];
    private string[] choices_string = new string[6];

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject ally;
    [SerializeField]
    private GameObject allyFire;

    [SerializeField]
    private Button button1;
    [SerializeField]
    private Button button2;
    [SerializeField]
    private Button button3;

    private void Awake()
    {
        instance = this;
    }

    public GameObject levelUpMenuUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        choices[0] = 0;
        choices[1] = 1;
        choices[2] = 2;

        choices_string[0] = "Fire Rate";
        choices_string[1] = "Power";
        choices_string[2] = "Number of Ally Slimes";
        choices_string[3] = "Bullets Duration";
        choices_string[4] = "Bullet Status Effect Fire";
        choices_string[5] = "Bullet Status Effect Ice";
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void BonusChoiceMenu()
    {
        levelUpMenuUI.SetActive(true);
        Time.timeScale = 0f;

        choices[0] = Random.Range(0, 6);
        choices[1] = Random.Range(0, 6);
        choices[2] = Random.Range(0, 6);

        while (choices[1] == choices[0]) choices[1] = Random.Range(0, 6);
        while (choices[2] == choices[0] || choices[2] == choices[1]) choices[2] = Random.Range(0, 6);

        button1.GetComponentInChildren<TMP_Text>().text = choices_string[choices[0]];
        button2.GetComponentInChildren<TMP_Text>().text = choices_string[choices[1]];
        button3.GetComponentInChildren<TMP_Text>().text = choices_string[choices[2]];

    }

    public void ButtonChoice1()
    {
        Upgrade(choices[0]);
    }

    public void ButtonChoice2()
    {
        Upgrade(choices[1]);
    }

    public void ButtonChoice3()
    {
        Upgrade(choices[2]);
    }

    private void Upgrade(int choice)
    {
        switch (choice)
        {
            case 0:
                player.GetComponent<PlayerBehaviour>().fireRate -= 0.05f;
                break;

            case 1:
                player.GetComponent<PlayerBehaviour>().power += 1;
                break;

            case 2:
                int rdm = Random.Range(0, 2);
                if (rdm == 0) player.GetComponent<SlimeAlliesManager>().AddSlime(ally);
                else player.GetComponent<SlimeAlliesManager>().AddSlime(allyFire);
                break;

            case 3:
                player.GetComponent<PlayerBehaviour>().GetComponent<BulletBehaviour>().Duration += 500;
                break;

            case 4:
                player.GetComponent<PlayerBehaviour>().GetComponent<BulletBehaviour>().StatusEffect = EnumList.StatusEffect.TICK;
                break;

            case 5:
                player.GetComponent<PlayerBehaviour>().GetComponent<BulletBehaviour>().StatusEffect = EnumList.StatusEffect.SLOW;
                break;

            default:
                Debug.Log("Unknown Choice...");
                break;

        }
        levelUpMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
