using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    // Gjord av Aiden
    // Statisk instans för Singleton-mönstret så andra script kan komma åt ShopManager enkelt
    public static ShopManager instance;

    // Spelarens totala antal coins
    public int coins = 0;

    
    public Upgrade[] upgrades;

    // Referenser till UI-element
    public Text coinstext;          
    public GameObject shopUI;       
    public Transform shopContent;   
    public GameObject itemPrefab;   
    public PlayerHealth Ph;        

    
    // Awake() körs innan Start(). Den sätter upp Singleton-mönstret
    // och ser till att objektet inte förstörs mellan scenbyten.
    private void Awake()
    {
        // Om det inte finns någon instans än, sätt denna som instans
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Om en instans redan finns, förstör denna kopia
            Destroy(gameObject);
        }

        // Förhindrar att objektet förstörs när en ny scen laddas
        DontDestroyOnLoad(gameObject);
    }

    
    
    private void Start()
    {
        // Gå igenom varje uppgradering som finns definierad i Inspectorn
        foreach (Upgrade upgrade in upgrades)
        {
            // Skapa ett nytt UI-objekt från prefab och ha det i shop meny
            GameObject item = Instantiate(itemPrefab, shopContent);

            // Spara en referens till detta UI-objekt i uppgraderings-datat
            upgrade.itemRef = item;

            // Gå igenom alla barnobjekt i det skapade item-objektet (t.ex. text och bilder)
            foreach (Transform child in item.transform)
            {
                // Uppdatera varje UI-element beroende på dess namn i hierarkin
                if (child.gameObject.name == "Quantity")
                {
                    // Visar hur många av denna uppgradering spelaren äger
                    child.gameObject.GetComponent<Text>().text = upgrade.quantity.ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    // Visar kostnaden för uppgraderingen 
                    child.gameObject.GetComponent<Text>().text = "$" + upgrade.cost.ToString();
                }
                else if (child.gameObject.name == "Name")
                {
                    // Visar Items namn
                    child.gameObject.GetComponent<Text>().text = upgrade.name;
                }
                else if (child.gameObject.name == "Image")
                {
                    // Visar Items bild
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }
            }
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuyUpgrade(upgrade);
            });

        }
    }
    //Köpa upgrade med pengar
    public void BuyUpgrade(Upgrade upgrade)
    {
        if (coins >= upgrade.cost)
        {
            coins -= upgrade.cost;
            upgrade.quantity++;
            upgrade.itemRef.transform.GetChild(0).GetComponent<Text>().text = upgrade.quantity.ToString();

           // ApplyUpgrade(upgrade);

        }
    }
    //Apply the upgrade to the player 
     public void ApplyUpgrade(Upgrade upgrade) {
        switch (upgrade.name)
        {
            case "Health":
                Ph.currentHealth += 20;
                break;
            default:
                Debug.Log("No upgrade available");
                    break;
        }
     
     }
    // Om den är öppen stängs den, och om den är stängd öppnas den
    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    
    // Här uppdateras texten som visar antalet coins under spelet
    private void OnGUI()
    {
        coinstext.text = "Coins: " + coins.ToString();
    }
}

// -----------------------------------------------------------
// En klass som innehåller information om varje uppgradering i shoppen.

[System.Serializable]
public class Upgrade
{
    public string name;      // Namnet på uppgraderingen som visas i UI
    public int cost;         // Kostnaden i coins för att köpa den
    public Sprite image;     // Bilden som visas i shoppen

    // Visar inte i inspector
    [HideInInspector] public int quantity;        // Hur många av denna uppgradering spelaren äger
    [HideInInspector] public GameObject itemRef;  // Referens till detta föremåls UI-objekt i shoppen
}