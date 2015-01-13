import java.util.Random;

/**
 * A match between two players can compute the winner.
 * 
 * @author Katharina Laube, Matthias Busch
 * @since 12.01.2015
 */
public class Match {

	private String playerName1;
	private String playerName2;

	public Match(String playerName1, String playerName2) {
		this.playerName1 = playerName1;
		this.playerName2 = playerName2;
	}

	public String computeWinner() {
		Random random = new Random();
		boolean hasPlayer1Won = random.nextBoolean();

		String winner;
		if (hasPlayer1Won) {
			winner = playerName1;
		} else {
			winner = playerName2;
		}

		System.out.println(playerName1 + " vs. " + playerName2 + ": Winner is "
				+ winner + "!");
		return winner;
	}

	@Override
	public String toString() {
		return playerName1 + " vs. " + playerName2;
	}

}
