namespace Infrastructure.Strategies;

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

    public bool CanMoveOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board)
    {
        return GetPossibleMoves(currentPosition).Contains(newPosition) 
               && (board.Board[newPosition[0]][newPosition[1]] != null 
                   || board.Board[newPosition[0]][newPosition[1]]!.Color != _figureColor);
    }
    
    public List<int[]> GetPossibleMoves(int[] currentPosition)
    {
        var possibleMoves = new List<int[]>();
        
        
        
        return PossibleMovesFilter.FilterPossibleMovesFieldLimited(possibleMoves);
    }

    #endregion
}