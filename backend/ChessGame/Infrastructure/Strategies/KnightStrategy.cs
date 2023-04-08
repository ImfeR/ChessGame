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

	#region Constants

	private const int TreeStepMove = 3;
	private const int OneStepMove = 1;

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
		var possibleMoves = new List<int[]>
		{
			new[] { currentPosition[0] + TreeStepMove, currentPosition[1] + OneStepMove },
			new[] { currentPosition[0] + OneStepMove, currentPosition[1] + TreeStepMove },

			new[] { currentPosition[0] - TreeStepMove, currentPosition[1] - OneStepMove },
			new[] { currentPosition[0] - OneStepMove, currentPosition[1] - TreeStepMove },

			new[] { currentPosition[0] + TreeStepMove, currentPosition[1] - OneStepMove },
			new[] { currentPosition[0] + OneStepMove, currentPosition[1] - TreeStepMove },

			new[] { currentPosition[0] - TreeStepMove, currentPosition[1] + OneStepMove },
			new[] { currentPosition[0] - OneStepMove, currentPosition[1] + TreeStepMove },
		};


		return PossibleMovesFilter.FilterPossibleMovesFieldLimited(possibleMoves);
	}

	#endregion
}