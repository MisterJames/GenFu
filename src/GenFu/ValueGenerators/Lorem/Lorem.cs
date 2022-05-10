namespace GenFu.ValueGenerators.Lorem;

using global::GenFu.Utilities;

using System.Text;

public class Lorem : BaseValueGenerator
{
    private static string GenerateWord()
     => GetRandomValue(ResourceLoader.Data(PropertyType.Lorem));

    public static string GenerateWords(int numberOfWords, int commaPosition = 0) =>
        numberOfWords == 0 ? string.Empty :
        new StringBuilder()
           .BuildFor(numberOfWords, (words, i) =>
              words
                .Append(GenerateWord())
                .AppendWhen(",", commaPosition > 0 && commaPosition == i)
                .Append(" "))
           .ToString()
           .TrimEnd(' ');

    public static string GenerateSentences(int numberOfSentences) =>
        numberOfSentences == 0 ? string.Empty :
        new StringBuilder()
            .BuildFor(numberOfSentences, GenerateSentence)
            .ToString()
            .TrimEnd(' ');

    private static StringBuilder GenerateSentence(StringBuilder sentenceBuilder)
    {
        int sentenceLength = StaticRandom.Instance.Next(6, 14);
        int commaPosition = sentenceLength < 10 ? 0 : sentenceLength / 2;
        string s = GenerateWords(sentenceLength, commaPosition);
        return sentenceBuilder.Append(s.UppercaseFirst()).Append(". ");
    }
}
