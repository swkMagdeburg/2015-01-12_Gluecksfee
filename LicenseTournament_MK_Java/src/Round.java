import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Set;

/**
 * A round has many players and can compute the matches. A dummy player will be
 * added if the number of players is uneven.
 * 
 * @author Katharina Laube, Matthias Busch
 * @since 12.01.2015
 */
public class Round {

	static final String DUMMY = "Dummy Player";

	private ArrayList<String> players = new ArrayList<>();
	private boolean dummy_was_added = false;

	private List<Match> matches = null;

	public Round(Set<String> players) {

		this.players.addAll(players);

		if (this.players.isEmpty()) {
			throw new IllegalStateException("Number of players must not be 0");
		}

		System.out.println("\nRound started with " + this.players);

		if (this.players.size() % 2 == 1) {
			this.players.add(DUMMY);
			System.out.println(DUMMY + " added!");
		}
	}

	public int getNumberOfRealPlayers() {
		int result = players.size();
		if (dummy_was_added) {
			result--;
		}

		return result;
	}

	public int getNumberOfPlayers() {
		return players.size();
	}

	public List<Match> computeMatches() {
		this.matches = new LinkedList<Match>();
		for (int i = 0; i < players.size() / 2; i++) {
			String playerName1 = players.get(i);
			String playerName2 = players.get(players.size() - i - 1);
			matches.add(new Match(playerName1, playerName2));
		}
		System.out.println(matches);
		return matches;
	}

}
