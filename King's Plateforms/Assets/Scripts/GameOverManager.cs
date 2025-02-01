using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        GameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        // Recommencer le niveau   
    }

    public void MainMenuButton()
    {
        // Retour au menu principal
    }

    public void QuitButton()
    {
        // Fermer le jeu
        Application.Quit();
    }
}
