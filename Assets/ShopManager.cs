using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public int coins = 0;
    public Upgrade[] upgrades;

    //referenser
    public Text coinstext;
    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;
    public PlayerHealth Ph;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        foreach (Upgrade upgrade in upgrades) 
        {
            GameObject item = Instantiate(itemPrefab, shopContent);

            upgrade.itemRef = item;

            foreach(Transform child in item.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.quantity.ToString();
                } 
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<Text>().text = "$" + upgrade.cost.ToString();
                }
                else if(child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.name;
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }
            }
        }
    }
    public void ToggleShop()
    {
        //om ShopUI år öppen så sätter koden den till falsk men om det är stängd så sätter det till sant.
        shopUI.SetActive(!shopUI.activeSelf);
    }
    private void OnGUI()
    {
        coinstext.text = "Coins" + coins.ToString();
    }
}

[System.Serializable]
public class Upgrade
{
    public string name;
    public int cost;
    public Sprite image;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
}