import static org.hamcrest.core.IsCollectionContaining.hasItem;
import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertThat;
import static org.junit.Assert.fail;

import java.util.HashSet;

import org.junit.Test;

/** 
 * @author Katharina Laube
 * @since 13.01.2015
 */
public class TournamentTest {

	@Test
	public void a_tournament_needs_at_least_one_player() {
		System.out.println("\n a_tournament_needs_at_least_one_player");
		
		try {
			new Round(new HashSet<>());
			fail("A tournament needs at least one player!");
		} catch (IllegalStateException e) {
			// expected
		}
	}

	@Test
	public void the_winner_must_be_one_of_the_four_players() {
		System.out.println("\n the_winner_must_be_one_of_the_four_players");
		
		final HashSet<String> players = TestHelper.createSetOfPlayers(4);
		final Tournament underTest = new Tournament(players);
		
		final String winner = underTest.computeWinner();
		
		assertNotNull(winner);
		assertThat(players, hasItem(winner));
	}

	@Test
	public void the_winner_must_be_one_of_the_five_players() {
		System.out.println("\n the_winner_must_be_one_of_the_five_players");
		
		final HashSet<String> players = TestHelper.createSetOfPlayers(5);
		final Tournament underTest = new Tournament(players);
		
		String winner = underTest.computeWinner();
		
		assertNotNull(winner);
		assertThat(players, hasItem(winner));
	}
}
