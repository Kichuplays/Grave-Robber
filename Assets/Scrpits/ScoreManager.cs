using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText; //Referar textmeshpro ui
    public int score = 0;
    
    public Upgrade[] upgrades;
    public Transform shopContent;
    public GameObject itemPrefab;
    public PlayerHealth pH;

    void Awake()
    {

        // Ensure only one ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
      
    }

    void Start()
    {
        UpdateScoreText();
        foreach(Upgrade upgrade in upgrades)
        {
            GameObject item = Instantiate(itemPrefab, shopContent);
            upgrade.itemRef = item;

            foreach(Transform child in item.transform)
            {
                if (child.gameObject.name == "quantity")
                {
                    child.gameObject.GetComponent<TextMeshPro>().text = upgrade.
                        quantity.ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<TextMeshPro>().text = "$" + upgrade.cost.ToString();
                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<TextMeshPro>().text = upgrade.Name;
                } else if(child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.icon;
                }
                

                


            }
            

            
        }
    }

    public void AddScore(int amount)
    {
        score += amount; // Increase score
        UpdateScoreText(); // Updaterar the UI
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score.ToString();
        }
    }
  
}


[System.Serializable]
public class Upgrade
{
    public string Name;
    public int cost;
    public Sprite icon;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;

}