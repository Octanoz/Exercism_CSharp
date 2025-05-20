namespace CryptoSquare.Tests;
using CryptoSquare;

public class CryptoSquareTests
{
    [Fact]
    public void Empty_plaintext_results_in_an_empty_ciphertext()
    {
        Assert.Equal("", Cypher.Ciphertext(""));
    }

    [Fact]
    public void Normalization_results_in_empty_plaintext()
    {
        Assert.Equal("", Cypher.Ciphertext("... --- ..."));
    }

    [Fact]
    public void Lowercase()
    {
        Assert.Equal("a", Cypher.Ciphertext("A"));
    }

    [Fact]
    public void Remove_spaces()
    {
        Assert.Equal("b", Cypher.Ciphertext("  b "));
    }

    [Fact]
    public void Remove_punctuation()
    {
        Assert.Equal("1", Cypher.Ciphertext("@1,%!"));
    }

    [Fact]
    public void Nine_character_plaintext_results_in_3_chunks_of_3_characters()
    {
        Assert.Equal("tsf hiu isn", Cypher.Ciphertext("This is fun!"));
    }

    [Fact]
    public void Eight_character_plaintext_results_in_3_chunks_the_last_one_with_a_trailing_space()
    {
        Assert.Equal("clu hlt io ", Cypher.Ciphertext("Chill out."));
    }

    [Fact]
    public void Fifty_four_character_plaintext_results_in_7_chunks_the_last_two_with_trailing_spaces()
    {
        Assert.Equal("imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau ", Cypher.Ciphertext("If man was meant to stay on the ground, god would have given us roots."));
    }

    [Fact]
    public void Fifty_four_character_plaintext_results_in_8_chunks_the_last_two_with_trailing_spaces()
    {
        Assert.Equal("imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau ", Cypher.Ciphertext("If man was meant to stay on the ground, god would have given us roots."));
    }
}
