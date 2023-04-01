namespace Infrastructure.Factories;

using Strategies;
using Entities;

public interface IFigureStrategyFactory
{
    public IFigureStrategy GetFigureStrategy(ChessFigure figure);
}