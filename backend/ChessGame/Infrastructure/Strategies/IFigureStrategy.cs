namespace Infrastructure.Strategies;

using _Enums_;

using Entities;

public interface IFigureStrategy
{
	public MovementType GetMovementTypeOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board);

	public List<int[]> GetPossibleMoves(int[] currentPosition);
}