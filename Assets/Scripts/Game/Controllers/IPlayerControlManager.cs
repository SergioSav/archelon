public interface IPlayerControlManager
{
	void SetPlayerController(IPlayerController playerController);
	void MoveUp();
	void MoveDown();
	void MoveLeft();
	void MoveRight();
}