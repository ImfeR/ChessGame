namespace Infrastructure.Strategies;

using _Enums_;

using Entities;
using Entities._Enums_;

using Validators;

public class KnightStrategy : IFigureStrategy
{
	#region Fields

	private readonly Color _figureColor;

	#endregion

	#region Constructors

	public KnightStrategy(Color color)
	{
		_figureColor = color;
	}

	#endregion

	#region Methods

	public MovementType GetMovementTypeOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board)
	{
		if (!GetPossibleMoves(currentPosition).Contains(newPosition)
		    || board.Board?[newPosition[0]][newPosition[1]]!.Color == _figureColor)
			return MovementType.None;

		return board.Board?[newPosition[0]][newPosition[1]] == null ? MovementType.Move : MovementType.Cut;
	}

	public List<int[]> GetPossibleMoves(int[] currentPosition)
	{
		var possibleMoves = new List<int[]>();


		return PossibleMovesFilter.FilterPossibleMovesFieldLimited(possibleMoves);
	}

	#endregion
}