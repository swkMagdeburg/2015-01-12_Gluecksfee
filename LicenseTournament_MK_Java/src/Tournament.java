import java.util.HashSet;
import java.util.List;
import java.util.Set;

/**
 * A tournament runs rounds with matches as long as only one player
 * would get to the next round. This player will be the winner of the tournament.
 * 
 * @author Katharina Laube
 * @since 13.01.2015
 */
public class Tournament {

	private Set<String> players;

	public Tournament(HashSet<String> players) {
		this.players = players;
		System.out.println("\nTournament started with " + this.players);
	}

	public String computeWinner() {

		Round round = new Round(players);
		final Set<String> winners = new HashSet<>();
		
		while (true) {
			List<Match> matches = round.computeMatches();
			for (Match match : matches) {
				String winner = match.computeWinner();
				if (!Round.DUMMY.equals(winner)){
					winners.add(winner);
				}
			}
			
			// one player left --> winner of tournament
			if(winners.size() == 1){
				String winnerOfTournament = winners.iterator().next();
				System.out.println("The winner of the tournament is " + winnerOfTournament + "!");
				return winnerOfTournament;
			}
			
			// next round with all winners
			round = new Round(winners);
			winners.clear();
		}
	}
}
