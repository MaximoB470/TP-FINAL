using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public interface IUImanager
{
    void ExitShop();
    void UpdateHealth(int health);
    void UpdatePoints(int points);
    void UpdateRound(int round);
    void ShowPauseMenu();
    void ShowVictoryMenu();
    void ShowDefeatMenu();
    void HideAllMenus();
}
public class UIManager : MonoBehaviour, IUImanager
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject healthTextObject;
    [SerializeField] private GameObject pointsTextObject;
    [SerializeField] private GameObject roundTextObject;
    [SerializeField] private GameObject roundTextObject2;
    [SerializeField] private GameObject waitTextObject;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private GameObject defeatMenu;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI pointsText;
    private TextMeshProUGUI roundText;

    private PlayerController playerController;
    private GameManager gameManager;

    public GameObject ShopMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        ServiceLocator.Instance.Register<UIManager>(this);
        HideAllMenus();
        playerController = ServiceLocator.Instance.GetService<PlayerController>();
        gameManager = ServiceLocator.Instance.GetService<GameManager>();
        ServiceLocator.Instance.Register<IUImanager>(this);

        if (healthTextObject != null)
        {
            healthText = healthTextObject.GetComponent<TextMeshProUGUI>();
        }
        if (pointsTextObject != null)
        {
            pointsText = pointsTextObject.GetComponent<TextMeshProUGUI>();
        }
        if (roundTextObject != null)
        {
            roundText = roundTextObject.GetComponent<TextMeshProUGUI>();
        }
        UpdateHealth(playerController != null ? playerController.HPTracker : 0);
        UpdatePoints(playerController != null ? playerController.points : 0);
        UpdateRound(gameManager != null ? gameManager.currentWave : 0);
    }
    private void Update()
    {
        if (playerController != null)
        {
            UpdateHealth(playerController.HPTracker);
            UpdatePoints(playerController.points);
        }
        if (gameManager != null)
        {
            UpdateRound(gameManager.currentWave);

            if (gameManager.isActive)
            {
                if (waitTextObject != null) waitTextObject.SetActive(true);
                if (roundTextObject != null) roundTextObject.SetActive(false);
                if (roundTextObject2 != null) roundTextObject2.SetActive(false);
            }
            else
            {
                if (waitTextObject != null) waitTextObject.SetActive(false);
                if (roundTextObject != null) roundTextObject.SetActive(true);
                if (roundTextObject2 != null) roundTextObject2.SetActive(true);
                if (ShopMenu != null) ShopMenu.SetActive(false);
            }
        }
    }
    public void ExitShop()
    {
        if (ShopMenu != null)
        {
            ShopMenu.SetActive(false);
        }
    }
    public void UpdateHealth(int health)
    {
        if (healthText != null)
        {
            healthText.text = $"{health}";
        }
    }
    public void UpdatePoints(int points)
    {
        if (pointsText != null)
        {
            pointsText.text = $"{points}";
        }
    }
    public void UpdateRound(int round)
    {
        if (roundText != null)
        {
            roundText.text = $"{round}";
        }
    }
    public void ShowPauseMenu()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }
    public void ShowVictoryMenu()
    {
        if (victoryMenu != null)
        {
            victoryMenu.SetActive(true);
        }
    }
    public void ShowDefeatMenu()
    {
        if (defeatMenu != null)
        {
            defeatMenu.SetActive(true);
        }
    }
    public void HideAllMenus()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        if (victoryMenu != null)
        {
            victoryMenu.SetActive(false);
        }
        if (defeatMenu != null)
        {
            defeatMenu.SetActive(false);
        }
    }

}