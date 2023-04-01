namespace Infrastructure.Strategies;

using Entities;

public interface IFigureStrategy
{
    public bool CanMoveOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board);
    
    public List<int[]> GetPossibleMoves(int[] currentPosition);
}