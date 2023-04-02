namespace Infrastructure.Strategies;

using _Enums_;

using Entities;
using Entities._Enums_;

using Validators;

public class KingStrategy : IFigureStrategy
{
	#region Fields

	private readonly Color _figureColor;

	#endregion

	#region Constructors

	public KingStrategy(Color color)
	{
		_figureColor = color;
	}

	#endregion

	#region Methods

	public MovementType GetMovementTypeOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board)
	{
		if (!GetPossibleMoves(currentPosition).Contains(newPosition))
			return MovementType.None;

		return MovementType.Move;

		// TODO: need change logic here
		// return GetPossibleMoves(currentPosition).Contains(newPosition) 
		//        && board.Board[newPosition[0]][newPosition[1]] != null 
		//        && board.Board[newPosition[0]][newPosition[1]]!.Color != _figureColor;
	}

	public List<int[]> GetPossibleMoves(int[] currentPosition)
	{
		var possibleMoves = new List<int[]>();

		for (var i = 0; i <= 1; i++)
		{
			for (var j = 0; j <= 1; j++)
			{
				if (j == 0 && i == 0)
					continue;

				possibleMoves.Add(new[] { currentPosition[0] + i, currentPosition[1] + j });
				possibleMoves.Add(new[] { currentPosition[0] - i, currentPosition[1] - j });
			}
		}

		possibleMoves.Add(new[] { currentPosition[0] + 1, currentPosition[1] - 1 });
		possibleMoves.Add(new[] { currentPosition[0] - 1, currentPosition[1] + 1 });

		return PossibleMovesFilter.FilterPossibleMovesFieldLimited(possibleMoves);
	}

	#endregion
}