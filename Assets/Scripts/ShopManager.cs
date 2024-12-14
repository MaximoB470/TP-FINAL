using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopManager
{
    void BuyDash();
    void BuyMedKit();
    void BuyEscape();
}
public class ShopManager : MonoBehaviour, IShopManager
{
    public static ShopManager Instance { get; private set; }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private int dashCost = 300;
    [SerializeField] private int escapeCost = 2000;
    [SerializeField] private int medkitCost = 300;

    [SerializeField] private GameObject medKitPrefab; 
    [SerializeField] private Transform spawnPoint;
    private MedKitFactory medKitFactory;

    private StateMachine state;
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
        ServiceLocator.Instance.Register<IShopManager>(this);
        if (playerController == null)
        {
            playerController = ServiceLocator.Instance.GetService<PlayerController>();
        }
    }
    public void BuyDash()
    {
        if (playerController != null && playerController.points >= dashCost)
        {
            playerController.points -= dashCost;
            playerController.UnlockDash();
        }
    }
    public void BuyMedKit()
    {
        if (playerController != null && playerController.points >= medkitCost)
        {
            playerController.points -= medkitCost;

            if (medKitFactory == null)
            {
                medKitFactory = new MedKitFactory();
            }
            MedKit medKit = medKitFactory.GetMedKit(10);
            GameObject medKitInstance = Instantiate(medKitPrefab, spawnPoint.position, Quaternion.identity);
            MedKitPickUp medKitPickUp = medKitInstance.GetComponent<MedKitPickUp>();
            if (medKitPickUp != null)
            {
                medKitPickUp.Initialize(medKit);
            }
        }
    }
    public void BuyEscape()
    {
        if (playerController != null && playerController.points >= escapeCost)
        {
            state = new StateMachine();
            playerController.points -= escapeCost;
            var gameManager = ServiceLocator.Instance.GetService<GameManager>();
            if (gameManager != null)
            {
                state.ChangeState(new VictoryState(state));
                gameManager.isActive = false;
            }
        }
    }
}
