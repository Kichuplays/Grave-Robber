
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
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

        if (other.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
        }
    }
}
