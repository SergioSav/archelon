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

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			_gameManager.MovePlayerUp();
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			_gameManager.MovePlayerDown();
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			_gameManager.MovePlayerLeft();
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			_gameManager.MovePlayerRight();
		}
	}
}
