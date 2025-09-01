using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   public Slider playerHealthSlider;
   public int maxHealth = 100; 
    public void TakeDamage(int damage)
    {
        playerHealthSlider.value -= damage;
    }
}
