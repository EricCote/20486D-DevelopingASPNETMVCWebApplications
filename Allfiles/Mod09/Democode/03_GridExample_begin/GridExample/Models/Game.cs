

namespace GridExample.Models;
public class Game
{
    public int GameId { get; set; }
    public string FirstCompetitorName { get; set; }
    public string SecondCompetitorName { get; set; }
    public string FirstCompetitorPhotoFileName { get; set; }
    public string SecondCompetitorPhotoFileName { get; set; }
    public string FinalScore { get; set; }
    public int GamesQuantity { get; set; }
}

