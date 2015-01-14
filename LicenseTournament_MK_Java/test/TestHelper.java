import java.util.HashSet;

/**
 * Creates test data which are needed in more than one test.
 * 
 * @author Katharina Laube
 * @since 14.01.2015
 */
public final class TestHelper {

	static HashSet<String> createSetOfPlayers(int numberOfPlayers) {
		HashSet<String> players = new HashSet<>();
		for (int i = 1; i <= numberOfPlayers; i++) {
			players.add("Player" + i);
		}
		return players;
	}
}
