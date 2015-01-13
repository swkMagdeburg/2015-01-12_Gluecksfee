import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertTrue;
import static org.junit.Assert.fail;

import org.junit.Before;
import org.junit.Test;

/**
 * @author Katharina Laube, Matthias Busch
 * @since 12.01.2015
 */
public class MatchTest {

	private static final String PLAYER_NAME_2 = "Katharina";
	private static final String PLAYER_NAME_1 = "Matthias";

	private static final int NUMBER_OF_TEST_RUNS = 100;

	private Match underTest;

	@Before
	public void setUp() throws Exception {
		underTest = new Match(PLAYER_NAME_1, PLAYER_NAME_2);
	}

	@Test
	public void winner_should_not_be_null() {
		System.out.println("\n winner_should_not_be_null");
		String result = underTest.computeWinner();
		assertNotNull("Spieler darf nicht null sein!", result);
	}

	@Test
	public void in_100_matches_each_player_should_win_at_least_once()
			throws Exception {
		System.out
				.println("\n in_100_matches_each_player_should_win_at_least_once");
		boolean player1_seen = false;
		boolean player2_seen = false;

		for (int i = 0; i < NUMBER_OF_TEST_RUNS; i++) {
			String currentWinner = underTest.computeWinner();

			if (currentWinner.equals(PLAYER_NAME_1)) {
				player1_seen = true;
			} else if (currentWinner.equals(PLAYER_NAME_2)) {
				player2_seen = true;
			} else {
				fail("Gewinner ist keiner der Spieler");
			}
			if (player1_seen && player2_seen) {
				return;
			}
		}
		assertTrue("Spieler 1 hat nie gewonnen", player1_seen);
		assertTrue("Spieler 2 hat nie gewonnen", player2_seen);
	}
}
