using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinsCount;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scéne");
        }

        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
    }
}
