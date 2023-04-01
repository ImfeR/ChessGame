namespace Infrastructure.Strategies;

using Validators;

using Entities;
using Entities._Enums_;

/// <summary>
/// Стратегия для пешки
/// </summary>
public class PawnStrategy : IFigureStrategy
{
    #region Constants
    
    private const int WhiteStartRow = 1;
    private const int BlackStartRow = 6;

    #endregion

    #region Fields
    
    private Color _figureColor;

    #endregion

    #region Constructors

    public PawnStrategy(Color figureColor)
    {
        _figureColor = figureColor;
    }

    #endregion

    #region Methods
    
    public bool CanMoveOnPosition(int[] currentPosition, int[] newPosition, ChessBoard board)
    {
        return GetPossibleMoves(currentPosition).Contains(newPosition)
               && (board.Board[newPosition[0]][newPosition[1]] == null
                   || board.Board[newPosition[0]][newPosition[1]]!.Color != _figureColor);
    }

    public List<int[]> GetPossibleMoves(int[] currentPosition)
    {
        var possibleMoves = new List<int[]> ();

        switch (_figureColor)
        {
            case Color.Black:
            {
                if (currentPosition[0] == BlackStartRow)
                    possibleMoves.Add(new[] { currentPosition[0] - 2, currentPosition[1] });
                
                possibleMoves.Add(new [] { currentPosition[0] - 1, currentPosition[1] });
                possibleMoves.Add(new [] { currentPosition[0] - 1, currentPosition[1] - 1 });
                possibleMoves.Add(new [] { currentPosition[0] - 1, currentPosition[1] + 1 });

                break;
            }
            case Color.White:
            {
                if (currentPosition[0] == WhiteStartRow)
                    possibleMoves.Add(new [] { currentPosition[0] + 2, currentPosition[1] });

                possibleMoves.Add(new [] { currentPosition[0] + 1, currentPosition[1] });
                possibleMoves.Add(new [] { currentPosition[0] + 1, currentPosition[1] - 1 });
                possibleMoves.Add(new [] { currentPosition[0] + 1, currentPosition[1] + 1 });
                break;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(_figureColor), _figureColor, null);
        }       
        
        return PossibleMovesFilter.FilterPossibleMovesFieldLimited(possibleMoves);
    }

    #endregion
}