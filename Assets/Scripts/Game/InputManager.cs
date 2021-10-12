using UnityEngine;

public class InputManager : MonoBehaviour, IInputManager
{
	private IGameManager _gameManager;

	public void SetGameManager(IGameManager gameManager)
	{
		_gameManager = gameManager;
	}

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_gameManager.QuitApplication();
		}

        var horizontalMoveAxis = SimpleInput.GetAxis("Horizontal");
        var verticalMoveAxis = SimpleInput.GetAxis("Vertical");
        if (horizontalMoveAxis > 0)
            _gameManager.MovePlayerRight();
        if (horizontalMoveAxis < 0)
            _gameManager.MovePlayerLeft();
        if (verticalMoveAxis > 0)
            _gameManager.MovePlayerUp();
        if (verticalMoveAxis < 0)
            _gameManager.MovePlayerDown();
	}
}
