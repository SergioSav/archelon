public interface IPlayerControlManager
{
	void SetPlayerController(IUnitController playerController);
	void MoveUp();
	void MoveDown();
	void MoveLeft();
	void MoveRight();
}