using System;
using Features.Core.UpdateManager;
using Features.Enemy.Scripts.Realization;
using Features.Player.Scripts.Realization;
using Features.UI.Scripts.Interfaces;
using Features.UI.Scripts.Realization;
using Features.UI.UIMainMenu.Scripts;
using UnityEngine;

public class ApplicationLauncher : MonoBehaviour
{
    [SerializeField] private NavMeshActorModel _enemyModel;
    [SerializeField] private CharacterControllerActorModel _playerModel;
    [SerializeField] private UpdateManager _updateManager;
    [SerializeField] private UIRoot _uiRoot;
    
    private IUIService _uiService;
    private PlayerSpawner _playerSpawner;
    private CharacterControllerActorSpawner _characterControllerActorSpawner;
    private NavMeshActorSpawner _navMeshActorSpawner;
    private RandomEnemySpawner _randomEnemySpawner;

    private InputHandler _inputHandler;

    private ActorStorage _enemyActorStorage;

    private EnemyStorageSpawnHandler _enemyStorageSpawnHandler;
    private PlayerInputHandler _playerInputHandler;
    private EnemyMovementHandler _enemyMovementHandler;
    
    private void Awake()
    {
        _inputHandler = new InputHandler();
        _updateManager.Add(_inputHandler);
        
        _characterControllerActorSpawner = new CharacterControllerActorSpawner();
        _navMeshActorSpawner = new NavMeshActorSpawner();
        _playerSpawner = new PlayerSpawner(_characterControllerActorSpawner);
        _uiService = new UIService(_uiRoot);
        _playerInputHandler = new PlayerInputHandler(_playerSpawner, _inputHandler);
        _randomEnemySpawner = new RandomEnemySpawner(_navMeshActorSpawner, new Vector2Int(-20, 20), new Vector2Int(-20, 20));
        _enemyActorStorage = new ActorStorage();
        _enemyStorageSpawnHandler = new EnemyStorageSpawnHandler(_enemyActorStorage, _randomEnemySpawner);
        _enemyMovementHandler = new EnemyMovementHandler(_playerSpawner, _enemyActorStorage);
        _updateManager.Add(_enemyMovementHandler);
    }

    private void Start()
    {
        var player = _playerSpawner.Spawn(_playerModel);

        //InitUIService(_uiRoot, _uiService);

        //var mainMenu = _uiService.Get<UIMainWindow>();
        //mainMenu.ShowEvent += MainMenuOnShowEvent;
        //mainMenu.HideEvent += MainMenuOnHideEvent;

        //_uiService.Show<UIMainWindow>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _randomEnemySpawner.Spawn(_enemyModel);
        }
    }

    private void MainMenuOnHideEvent(object sender, EventArgs e)
    {
        _uiService.Get<UIMainWindow>().PlayButtonPressed -= OnMainMenuPlayButtonPressed;
    }

    private void MainMenuOnShowEvent(object sender, EventArgs e)
    {
        _uiService.Get<UIMainWindow>().PlayButtonPressed += OnMainMenuPlayButtonPressed;
    }

    private void OnMainMenuPlayButtonPressed(object sender, EventArgs e)
    {
        //spawn player
        //start to spawn enemies
    }

    private void InitUIService(IUIRoot root, IUIService service)
    {
        _uiService.LoadWindows();
        var container = new GameObject("DeactivatedWindows");
        var containerRect = container.AddComponent<RectTransform>();
        containerRect.SetParent(_uiRoot.Container);
        containerRect.localScale = Vector3.one;
        containerRect.anchorMin = Vector2.zero;
        containerRect.anchorMax = Vector2.one;
        containerRect.pivot = new Vector2(0.5f, 0.5f);
        containerRect.offsetMin = Vector2.zero;
        containerRect.offsetMax = Vector2.zero;

        container.gameObject.SetActive(false);

        _uiService.InitWindows(containerRect);
    }
}
