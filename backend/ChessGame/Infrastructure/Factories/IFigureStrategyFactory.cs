namespace Infrastructure.Factories;

using Entities;

using Strategies;

public interface IFigureStrategyFactory
{
	public IFigureStrategy GetFigureStrategy(ChessFigure figure);
}