using System.Text;
using GenFu.Utilities;

namespace GenFu.ValueGenerators.Lorem
{
    public class Lorem : BaseValueGenerator
    {
        private static string GenerateWord()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Lorem));
        }

        public static string GenerateWords(int numberOfWords, int commaPosition = 0) =>
            numberOfWords == 0 ? string.Empty :
            new StringBuilder()
               .BuildFor(numberOfWords, (words, i) =>
                  words
                    .Append(GenerateWord())
                    .AppendWhen(",", () => commaPosition > 0 && commaPosition == i)
                    .Append(" "))
               .ToString()
               .TrimEnd(' ');

        public static string GenerateSentences(int numberOfParagraphs) =>
            numberOfParagraphs == 0 ? string.Empty :
            new StringBuilder()
                .BuildFor(numberOfParagraphs, GenerateSentence)
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
}

