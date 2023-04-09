namespace Infrastructure.Strategies;

using _Enums_;

using Entities;
using Entities._Enums_;

using Validators;

public class QueenStrategy : IFigureStrategy
{
	#region Constructors

	public QueenStrategy(Color figureColor)
	{
		_figureColor = figureColor;
	}

	#endregion

	#region Fields

	private readonly Func<int[], int, int[]> _axisPlus = (position, increment) =>
		new[] { position[0] + increment, position[1] };

	private readonly Func<int[], int, int[]>
		_axisMinus = (position, increment) => new[] { position[0] - increment, position[1] };

	private readonly Func<int[], int, int[]> _ordinatePlus =
		(position, increment) => new[] { position[0], position[1] + increment };

	private readonly Func<int[], int, int[]> _ordinateMinus =
		(position, increment) => new[] { position[0], position[1] - increment };

	private readonly Func<int[], int, int[]> _rightDiagPlus = (position, increment) =>
		new[] { position[0] + increment, position[1] + increment };

	private readonly Func<int[], int, int[]>
		_rightDiagMinus = (position, increment) => new[] { position[0] - increment, position[1] + 1 };

	private readonly Func<int[], int, int[]> _leftDiagPlus =
		(position, increment) => new[] { position[0] + increment, position[1] - increment };

	private readonly Func<int[], int, int[]> _leftDiagMinus =
		(position, increment) => new[] { position[0] - increment, position[1] - increment };

	private readonly Color _figureColor;

	#endregion

	#region Methods

	public MovementType GetMovementTypeOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board)
	{
		if (!GetPossibleMoves(currentPosition).Contains(newPosition)
		    || IsSomeFigureBetweenPositions(currentPosition, newPosition, board)
		    || board.Board?[newPosition[0]][newPosition[1]]!.Color == _figureColor)
			return MovementType.None;

		return board.Board?[newPosition[0]][newPosition[1]] == null ? MovementType.Move : MovementType.Cut;
	}

	public List<int[]> GetPossibleMoves(int[] currentPosition)
	{
		var possibleMoves = new List<int[]>();

		for (var i = 1; i <= 7; i++)
		{
			possibleMoves.Add(new[] { currentPosition[0] + i, currentPosition[1] });
			possibleMoves.Add(new[] { currentPosition[0] - i, currentPosition[1] });
			possibleMoves.Add(new[] { currentPosition[0], currentPosition[1] + i });
			possibleMoves.Add(new[] { currentPosition[0], currentPosition[1] - i });
			possibleMoves.Add(new[] { currentPosition[0] + i, currentPosition[1] + i });
			possibleMoves.Add(new[] { currentPosition[0] - i, currentPosition[1] - i });
			possibleMoves.Add(new[] { currentPosition[0] + i, currentPosition[1] - i });
			possibleMoves.Add(new[] { currentPosition[0] - i, currentPosition[1] + i });
		}

		return PossibleMovesFilter.FilterPossibleMovesFieldLimited(possibleMoves);
	}

	private bool IsSomeFigureBetweenPositions(int[] currentPosition, int[] newPosition, ChessBoard board)
	{
		var direction = GetMoveDirection(currentPosition, newPosition);

		var tempPosition = currentPosition;

		while (tempPosition[0] != newPosition[0] && tempPosition[1] != newPosition[1])
		{
			tempPosition = direction(tempPosition, 1);

			if (board.Board?[tempPosition[0]][tempPosition[1]] != null)
				return true;
		}

		return false;
	}

	private Func<int[], int, int[]> GetMoveDirection(IReadOnlyList<int> currentPosition, IReadOnlyList<int> newPosition)
	{
		if (currentPosition[0] == newPosition[0])
			return currentPosition[1] >= newPosition[1] ? _ordinatePlus : _ordinateMinus;

		if (currentPosition[1] == newPosition[1])
			return currentPosition[0] >= newPosition[0] ? _axisPlus : _axisMinus;

		if (currentPosition[0] < newPosition[0])
			return currentPosition[1] <= newPosition[1] ? _rightDiagPlus : _leftDiagPlus;

		return currentPosition[1] < newPosition[1] ? _rightDiagMinus : _leftDiagMinus;
	}

	#endregion
}