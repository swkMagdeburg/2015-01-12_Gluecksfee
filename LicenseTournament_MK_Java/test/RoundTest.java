import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.fail;

import java.util.HashSet;
import java.util.List;

import org.junit.Test;

/**
 * @author Katharina Laube, Matthias Busch
 * @since 12.01.2015
 */
public class RoundTest {

	@Test
	public void a_round_needs_at_least_one_player() {
		System.out.println("\na_round_needs_at_least_one_player");
		
		try {
			new Round(new HashSet<>());
			fail("A round needs at least one player!");
		} catch (IllegalStateException e) {
			// expected
		}
	}

	@Test
	public void when_round_has_three_player_dummy_should_be_added() {
		System.out.println("\n when_round_has_three_player_dummy_should_be_added");
		
		Round underTest = new Round(TestHelper.createSetOfPlayers(3));
		assertEquals("Wrong number of players", 4, underTest.getNumberOfPlayers());
	}

	@Test
	public void when_round_has_four_players_two_matches_should_be_run() {
		System.out.println("\n when_round_has_four_players_two_matches_should_be_run");

		Round underTest = new Round(TestHelper.createSetOfPlayers(4));
		List<Match> result = underTest.computeMatches();
		assertNotNull("Es sollte mindestens 1 Match geben - ", result);
		assertEquals("Falsche Anzahl Matches - ", 2, result.size());
	}

}
