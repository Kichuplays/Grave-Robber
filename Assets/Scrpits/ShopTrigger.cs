using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    // gjord av Aiden
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Om ett gameobject(Spelaren) går inne i collidern med taggen "Player" så kommmer shopen att toggla på
        if (other.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // När spelaren lämnar collidern stänger shoppen av 
        if (other.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
        }
    }
}
