namespace Infrastructure.Factories;

using Entities;
using Entities._Enums_;

using Strategies;

public class FigureStrategyFactory : IFigureStrategyFactory
{
	public IFigureStrategy GetFigureStrategy(ChessFigure figure)
	{
		return figure.Type switch
		{
			ChessFigureType.Bishop => throw new NotImplementedException(),
			ChessFigureType.King => new KingStrategy(figure.Color),
			ChessFigureType.Knight => new KnightStrategy(figure.Color),
			ChessFigureType.Pawn => new PawnStrategy(figure.Color),
			ChessFigureType.Queen => throw new NotImplementedException(),
			ChessFigureType.Rook => throw new NotImplementedException(),
			_ => throw new ArgumentException(nameof(figure.Type)),
		};
	}
}