using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }

        GameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);

        // Recharge la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PlayerHealth.instance.Respawn();
        GameOverUI.SetActive(false);
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
