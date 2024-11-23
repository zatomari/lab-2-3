using Lab3.Dialog;
using Lab3.Vocabulary;

public class Program {
    public static async Task Main() {
        Vocabulary vocabulary = new Vocabulary("Dictionary.db");

        await new DialogMain(vocabulary).Run("");
    }
}
