namespace Infrastructure.Validators;

public static class PossibleMovesFilter
{
	#region Methods

	/// <summary>
	///     Валидирует движения на выходи из поля
	/// </summary>
	/// <param name="possibleMoves">Все возможные движения (шаги) фигуры.</param>
	/// <returns>Отфильрованные движения (шаги)</returns>
	public static List<int[]> FilterPossibleMovesFieldLimited(IEnumerable<int[]> possibleMoves)
	{
		return possibleMoves.Where(move =>
			                           move[0] >= BottomLimit
			                           && move[0] <= TopLimit
			                           && move[1] <= TopLimit
			                           && move[1] >= BottomLimit)
		                    .ToList();
	}

	#endregion

	#region Constants

	private const int BottomLimit = 0;
	private const int TopLimit = 7;

	#endregion
}