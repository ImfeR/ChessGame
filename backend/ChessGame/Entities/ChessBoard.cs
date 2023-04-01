namespace Entities;

public class ChessBoard
{
    public int Id { get; set; }
    
    public ChessFigure?[][] Board { get; set; }
}